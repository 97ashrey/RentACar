using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Events.Messages
{
    public class CrudOperationMessage : IApplicationEvent
    {
        public enum CrudOperation
        {
            Create,
            Read,
            Update,
            Delete
        }

        public enum CrudResult
        {
            Success,
            Error
        }

        public CrudOperation Operation { get; private set; }
        public CrudResult Result { get; private set; }

        public CrudOperationMessage(CrudOperation operation, CrudResult result)
        {
            Operation = operation;
            Result = result;
        }
    }
}
