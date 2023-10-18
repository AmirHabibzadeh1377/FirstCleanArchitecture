using System.Collections.Generic;

namespace CleanArichitecture.Application.Responses
{
    public class BaseCommandResponse
    {
        public string Message { get; set; }
        public bool  Success { get; set; }
        public List<string> Errors{ get; set; }
        public int Id { get; set; }
    }
}