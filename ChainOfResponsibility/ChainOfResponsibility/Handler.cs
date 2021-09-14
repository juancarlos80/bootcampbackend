namespace ChainOfResponsibility
{
    public interface Handler
    {
        public void SetHandler(Handler handler);

        public void Process(File file);

        public string GetHandlerName();
    }
}