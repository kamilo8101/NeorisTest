using System.Data.SqlClient;

namespace Neoris.Common
{
    public class EntityResult<T>
    {
        public bool IsCorrect { get; private set; }
        public string Message { get; set; }
        public string InnerException { get; private set; }
        public int ErrorCode { get; set; }
        public IList<T> DataList { get; set; }
        public ICollection<string> ErrorList { get; private set; }
        public T SimpleObject { get; set; }

        public bool HasData
        {
            get
            {
                return (DataList != null && DataList.Count > 0);
            }
        }

        public EntityResult()
        {
            Message = "Correcto!";
            IsCorrect = true;
        }

        public EntityResult(string errorMessage)
        {
            Message = errorMessage;
            IsCorrect = false;
        }

        public EntityResult(T obj)
        {
            if (obj != null)
            {
                Message = "Correcto!";
                IsCorrect = true;
            }
            else
            {
                Message = "No hay datos";
                IsCorrect = false;
            }
            SimpleObject = obj;
        }

        public EntityResult(List<T> list)
        {
            if (list != null && list.Count > 0)
            {
                Message = "Correcto!";
                IsCorrect = true;
                DataList = list;
            }
            else
            {
                Message = "No hay datos";
                IsCorrect = false;
            }
        }

        public EntityResult(Exception e)
        {
            SqlException sqlException = e.InnerException.InnerException as SqlException;

            if (sqlException != null)
            {
                switch (sqlException.Number)
                {
                    case 2627:  // Unique constraint error
                        Message = "Clave Unica Violada";
                        break;

                    case 547:   // Constraint check violation
                        Message = "Restricción Check Violada";
                        break;

                    case 2601:  // Duplicated key row error
                        Message = "Clave Primaria Duplicada";
                        break;

                    default:
                        Message = "Error desconocido durante el proceso!";
                        break;
                }
            }
            else
            {
                Message = "Error desconocido durante el proceso!";
            }
            ErrorCode = sqlException.Number;
            InnerException = e.Message;
            IsCorrect = false;
        }

        public EntityResult(List<string> e)
        {
            ErrorList = new HashSet<string>(e);
            Message = "Hay errores de validación!";
            IsCorrect = false;
        }
    }
}