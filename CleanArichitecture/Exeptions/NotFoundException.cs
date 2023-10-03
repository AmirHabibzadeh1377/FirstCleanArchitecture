using System;

namespace CleanArichitecture.Application.Exeptions
{
    public class NotFoundException:ApplicationException
    {
        public NotFoundException(string name,object key):
            base($"{name} (${key}) was not found")
        {

        }
    }
}