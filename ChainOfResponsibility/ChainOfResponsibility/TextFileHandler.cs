using System;

namespace ChainOfResponsibility
{
    public class TextFileHandler : Handler
    {
        public Handler handler { set; get; }
        public string handlerName { set; get; }

        public TextFileHandler(string handlerName)
        {
            this.handlerName = handlerName;
        }

        public void SetHandler(Handler handler)
        {
            this.handler = handler;
        }

        public void Process(File file)
        {
            if (file.fileType.Equals("text"))
            {
                Console.WriteLine(
                    "{0}: manage the file: {1}",
                    handlerName,
                    file.fileName);
            }
            else
            {
                if(this.handler != null)
                {
                    this.handler.Process(file);
                }
                else
                {
                    Console.WriteLine("Error is not support a TextFileHandler = " + this.handlerName);
                }                
            }
        }

        public string GetHandlerName()
        {
            return this.handlerName;
        }
    }
}