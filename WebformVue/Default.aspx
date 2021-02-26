<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebformVue.Default" %>

<asp:Content ID="Content1"
             ContentPlaceHolderID="body"
             runat="server">
<div id="app"
     class="row"
     style="display: none">
    <div class="col-md-4">
        <form autocomplete="off"
              v-on:submit.prevent="submitForm">

            <input type="hidden" v-model="vModel.ViewModel.Id" />

            <div class="form-group">
                <label class="control-label"
                       for="Name">
                    姓名
                </label>
                <input class="form-control"
                       type="text"
                       name="Name"
                       v-model="vModel.ViewModel.Name"
                       v-on:blur="onBlur($event)">
                <span class="text-danger field-validation-valid">{{vModel.ValidateResult.Name?.join('、')}}</span>
            </div>

            <div class="form-group">
                <label class="control-label"
                       for="Password">
                    密碼
                </label>
                <input class="form-control"
                       type="password"
                       name="Password"
                       v-model="vModel.ViewModel.Password"
                       v-on:blur="onBlur($event)">
                <span class="text-danger field-validation-valid">{{vModel.ValidateResult.Password?.join('、')}}</span>
            </div>

            <div class="form-group">
                <label class="control-label"
                       for="RePassword">
                    確認密碼
                </label>
                <input class="form-control"
                       type="password"
                       name="RePassword"
                       v-model="vModel.ViewModel.RePassword"
                       v-on:blur="onBlur($event)">
                <span class="text-danger field-validation-valid">{{vModel.ValidateResult.RePassword?.join('、')}}</span>
            </div>

            <div class="form-group">
                <label class="control-label"
                       for="Age">
                    年齡
                </label>
                <input class="form-control"
                       type="number"
                       name="Age"
                       v-model="vModel.ViewModel.Age"
                       v-on:blur="onBlur($event)">
                <span class="text-danger field-validation-valid">{{vModel.ValidateResult.Age?.join('、')}}</span>
            </div>

            <div class="form-group">
                <label class="control-label"
                       for="Gendor">
                    性別
                </label>
                <br>

                <div v-for="(gendor, index) in gendorsOptions"
                     class="form-check form-check-inline"
                     :class="{'ml-3' : index === 0}">
                    <input class="form-check-input"
                           type="radio"
                           name="Gendor"
                           v-model="vModel.ViewModel.Gendor"
                           :id="gendor.Text"
                           :value="gendor.Value"
                           v-on:blur="onBlur($event)">
                    <label class="form-check-label"
                           :for="gendor.Text">
                        {{gendor.Text}}
                    </label>
                </div>
                <br>

                <span class="text-danger field-validation-valid">{{vModel.ValidateResult.Gendor?.join('、')}}</span>
            </div>

            <div class="form-group">
                <label class="control-label">就讀學校</label>
                <div class="form-group form-inline ml-3">
                    <div class="form-check form-check-inline">
                        <input class="form-check-input"
                               type="radio"
                               name="SchoolType"
                               v-model="vModel.ViewModel.SchoolType"
                               id="SchoolType.Option"
                               :value=1
                               v-on:blur="onBlur($event)">
                        <label class="form-check-label"
                               for="SchoolType.Option">
                            清單
                        </label>
                    </div>
                    <div class="form-group">
                        <select class="form-control"
                                v-model="vModel.ViewModel.SchoolOptionGuid"
                                name="SchoolType"
                                v-on:blur="onBlur($event)"
                                :disabled="vModel.ViewModel.SchoolType !== 1">
                            <option>請選擇</option>
                            <option v-for="school in schoolOptions"
                                    :value="school.Value">
                                {{school.Text}}
                            </option>
                        </select>
                    </div>
                </div>
                <div class="form-group ml-3">
                    <div class="form-check form-check-inline">
                        <input class="form-check-input"
                               type="radio"
                               name="SchoolType"
                               v-model="vModel.ViewModel.SchoolType"
                               id="SchoolType.Custom"
                               :value=2
                               v-on:blur="onBlur($event)">
                        <label class="form-check-label"
                               for="SchoolType.Custom">
                            自訂
                        </label>
                    </div>
                    <div class="form-group">
                        <input type="text"
                               class="form-control"
                               name="SchoolType"
                               v-model="vModel.ViewModel.CustomSchoolName"
                               v-on:blur="onBlur($event)"
                               :disabled="vModel.ViewModel.SchoolType !== 2">
                    </div>
                </div>
                <span class="text-danger field-validation-valid">{{vModel.ValidateResult.SchoolType?.join('、')}}</span>
            </div>

            <div class="form-group">
                <label class="control-label">興趣</label>
                <div class="form-group form-inline ml-3">
                    <div class="form-check form-check-inline"
                         v-for="interest in interestsOptions"
                         v-bind:key="interest.Value">
                        <input class="form-check-input"
                               type="checkbox"
                               v-model="vModel.ViewModel.Interests"
                               :id="'interest'+ interest.Value"
                               :value="interest.Value"
                               v-on:blur="onBlur($event)">
                        <label class="form-check-label"
                               :for="'interest'+ interest.Value">
                            {{interest.Text}}
                        </label>
                    </div>
                </div>
            </div>

            <div class="form-group">
                <input type="submit"
                       value="Save"
                       class="btn btn-primary">
            </div>
        </form>
    </div>
</div>

</asp:Content>
<asp:Content ID="Content2"
             ContentPlaceHolderID="script"
             runat="server">

    <script src="https://unpkg.com/vue@next"></script>
    <script src="https://cdn.jsdelivr.net/npm/axios/dist/axios.min.js"></script>

    <script>
      const gendors   = <%= GendorsJson %>;
      const schools   = <%= SchoolOptionsJson %>;
      const interests = <%= InterestsJson %>;
      const submitUrl = '';
      const actionName = '新增';
      const vm = {

          Interests : []
      };

      const { createApp, reactive } = Vue;

      const app = createApp({
        setup() {
            const gendorsOptions = gendors;
            const schoolOptions = schools;
            const interestsOptions = interests;

            const vModel = reactive({
                ViewModel : vm,

                // 驗証結果，用來放到 class="text-danger" 的 span 內的
                ValidateResult :
                {
                    Name : [],
                    Password : [],
                    RePassword : [],
                    Age : [],
                    Gendor : [],
                    SchoolType : [],
                }
            });

            // 曾經 Blur 的 Dom Id 清單，用來回傳給後端進行驗証用
            let ValidateProperties = new Set();

            function onBlur(e){
              const domId = e.target.name;
              console.log(domId);
              ValidateProperties.add(domId);

              validateViewModel();
            }

            // 向後端進行驗証
            function validateViewModel(){
              axios.post('/Home/Validate',
                         {
                             ValidateProperties: Array.from(ValidateProperties),
                             ViewModel: vModel.ViewModel,
                         },
                         {
                            headers: {
                                'Content-Type': 'application/json'
                            }
                         })
                    .then(response => {
                        const responseDto = response.data;

                        if (responseDto.StatusCode === 200 )
                        {
                            vModel.ValidateResult = [];
                        }
                        else if (responseDto.StatusCode === 400 )
                        {
                            vModel.ValidateResult = responseDto.ValidateResult;
                        }
                    });
            }

            function submitForm(){
                console.table('ViewModel', vModel.ViewModel);

                // Submit 就驗証所有欄位
                ValidateProperties = ['Name', 'Password', 'Age', 'Gendor', 'SchoolType', 'Interests'];

                axios.post(submitUrl,
                           {
                               ValidateProperties: Array.from(ValidateProperties),
                               ViewModel: vModel.ViewModel,
                           },
                           {
                              headers: {
                                  'Content-Type': 'application/json'
                              }
                           })
                      .then(response => {
                          const responseDto = response.data;
                             if (responseDto.StatusCode === 200 )
                          {
                              alert(actionName + "成功");
                              window.location.href = '/Home';
                          }
                          else if (responseDto.StatusCode === 400 )
                          {
                              vModel.ValidateResult = responseDto.ValidateResult;
                          }
                         });
            }

            return {
                gendorsOptions,
                schoolOptions,
                interestsOptions,
                vModel,
                ValidateProperties,
                onBlur,
                submitForm,
            };
        },
      });
      app.mount("#app");

      window.addEventListener('DOMContentLoaded', (event) => {
        document.getElementById("app").style.display = "block";
      });
    </script>

</asp:Content>

