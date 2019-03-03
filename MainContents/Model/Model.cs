using Prism.Mvvm;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainContents.Model
{
    public class Model: BindableBase
    {
        private string modelToViewString;
        public string ModelToViewString
        {
            get { return modelToViewString; }
            set { SetProperty(ref modelToViewString, value); }
        }

        private string modelToViewStringTwoWay;
        public string ModelToViewStringTwoWay
        {
            get { return modelToViewStringTwoWay; }
            set { SetProperty(ref modelToViewStringTwoWay, value); }
        }

        public ObservableCollection<string> ModelToViewCollection { get; }

        public ObservableCollection<Customer> ModelToViewCustomerCollection { get; }

        public Model()
        {
            ModelToViewString = "テスト";

            ModelToViewStringTwoWay = "テスト（書き換え可能）";

            ModelToViewCollection = new ObservableCollection<string>()
            {
                "テスト1",
                "テスト2"
            };

            ModelToViewCustomerCollection = new ObservableCollection<Customer>()
            {
                new Customer(){ ID = "1111", Name = "山田太郎"},
                new Customer(){ ID = "2222", Name = "佐藤二朗"}
            };
        }

        public void AddItemToCollection()
        {
            ModelToViewCollection.Add("テスト");
        }

        public void AddCustomerItemToCollection()
        {
            ModelToViewCustomerCollection.Add(new Customer() { ID = "3333", Name = "鈴木三郎" });
        }
    }
}
