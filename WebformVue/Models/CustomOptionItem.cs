namespace WebformVue.Models
{
    public class CustomOptionItem<T>
    {
        public string Text { get; set; }

        public T Value { get; set; }
    }
}