using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainContents.Model
{
    public class Customer: BindableBase
    {
        /// <summary>
        /// 氏名
        /// </summary>
        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }
        /// <summary>
        /// ユーザーID
        /// </summary>
        private string id;
        public string ID
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }
    }
}
