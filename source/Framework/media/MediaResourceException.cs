using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.media
{
    /// <summary>
    /// Represent an error while getting information through media resources.
    /// </summary>
    public class MediaResourceException : Exception
    {

        public Exception _realInnerException;
        public Exception RealInnerException { get { return _realInnerException; } }

        public string _message;
        public override string Message
        {
            get
            {
                return base.Message + Environment.NewLine + _message;
            }
        }


        public MediaResourceException(Exception ex)
        {
            _realInnerException = ex;
        }

        public MediaResourceException(Exception ex, string msg)
        {
            _realInnerException = ex;
            _message = msg;
        }

    }
}
