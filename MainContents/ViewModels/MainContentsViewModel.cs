using Prism.Commands;
using Prism.Mvvm;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using MainContents.Model;
using Reactive.Bindings.Extensions;

namespace MainContents.ViewModels
{
    public class MainContentsViewModel : BindableBase, IDisposable
    {
        #region Model->View
        public ReadOnlyReactiveProperty<string> ModelToViewString { get; }
        #endregion

        #region Model<->View
        public ReactiveProperty<string> ModelToViewStringTwoWay { get; }
        #endregion

        #region Model->Viewリスト
        public ReadOnlyReactiveCollection<string> ModelToViewCollection { get; }
        public ReactiveCommand AddItemToCollection { get; }
        #endregion

        public ReadOnlyReactiveCollection<Customer> ModelToViewCustomerCollection { get; }
        public ReactiveCommand AddCustomerItemToCollection { get; }

        private System.Reactive.Disposables.CompositeDisposable disposables = new System.Reactive.Disposables.CompositeDisposable();

        public MainContentsViewModel()
        {
            Model.Model model = new Model.Model();
            #region Model->View
            ModelToViewString = model.ObserveProperty(x => x.ModelToViewString)
                .ToReadOnlyReactiveProperty()
                .AddTo(disposables);
            #endregion

            #region Model<->View
            ModelToViewStringTwoWay = model.ObserveProperty(x => x.ModelToViewStringTwoWay)
                .ToReactiveProperty()
                .AddTo(disposables);
            #endregion

            #region Model->Viewリスト
            ModelToViewCollection = model.ModelToViewCollection.ToReadOnlyReactiveCollection()
                .AddTo(disposables);

            AddItemToCollection = new ReactiveCommand()
                .AddTo(disposables);
            AddItemToCollection.Subscribe(_ =>
            {
                model.AddItemToCollection();
            });
            #endregion

            ModelToViewCustomerCollection = model.ModelToViewCustomerCollection.ToReadOnlyReactiveCollection()
                .AddTo(disposables);

            AddCustomerItemToCollection = new ReactiveCommand()
                .AddTo(disposables);
            AddCustomerItemToCollection.Subscribe(_ =>
            {
                model.AddCustomerItemToCollection();
            });
        }

        public void Dispose()
        {
            disposables.Dispose();
        }
    }
}
