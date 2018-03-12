using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataContracts
{
    public class SaveResult<T>
    {
        public SaveResult(T result)
        {
            this.Result = result;
            this.Success = true;
        }

        public SaveResult(params string[] errors)
        {
            Errors = errors;
            this.Success = false;
        }

        public bool Success { get; set; }

        public T Result { get; set; }

        public IEnumerable<string> Errors { get; set; }

    }

    public class DeleteResult
    {
        public DeleteResult(params string[] errors)
        {
            this.Success = errors.Count() == 0;

            this.Errors = errors;
        }
        

        public bool Success { get; set; }

        public IEnumerable<string> Errors { get; set; }

    }
}
