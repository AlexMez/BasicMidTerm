using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermBasic
{
    class Books
    {

        string Title;
        string Author;
        string Status;
        string DueDate;

        public string BTitle
        {
            get
            {
                return Title;
            }

            set
            {
                Title = value;
            }
        }

        public string BAuthor
        {
            get
            {
                return Author;
            }

            set
            {
                Author = value;
            }
        }

        public string BStatus
        {
            get
            {
                return Status;
            }

            set
            {
                Status = value;
            }
        }

        public string BDueDate
        {
            get
            {
                return DueDate;
            }

            set
            {
                DueDate = value;
            }
        }

        public Books(string inputTitle, string inputAuthor, string inputStatus, string inputDueDAte)
        {
            BTitle = inputTitle;
            BAuthor = inputAuthor;
            BStatus = inputStatus;
            BDueDate = inputDueDAte;
        }

    }
}
