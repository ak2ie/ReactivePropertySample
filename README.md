# ReactivePropertyサンプル
## Model -> View（一方通行）
### Model
BindableBaseを継承し、プロパティを作る。
```
public class Model: BindableBase
    {
        private string modelToViewString;
        public string ModelToViewString
        {
            get { return modelToViewString; }
            set { SetProperty(ref modelToViewString, value); }
        }

        public Model()
        {
            ModelToViewString = "テスト";
        }
    }
```

### ViewModel
ObservePropertyからReadOnlyReactivePropertyを生成する。
（一方通行なのでReadOnly）
```
public ReadOnlyReactiveProperty<string> ModelToViewString { get; }

ModelToViewString = model.ObserveProperty(x => x.ModelToViewString)
                .ToReadOnlyReactiveProperty()
                .AddTo(disposables);
```

## Model <-> View（同期）
### Model
BindableBaseを継承し、プロパティを作る。（一方通行と同じ）
```
public class Model: BindableBase
    {
        private string modelToViewStringTwoWay;
        public string ModelToViewStringTwoWay
        {
            get { return modelToViewStringTwoWay; }
            set { SetProperty(ref modelToViewStringTwoWay, value); }
        }

        public Model()
        {
            ModelToViewStringTwoWay = "テスト（書き換え可能）";
        }
    }
```

### ViewModel
ObservePropertyからReactivePropertyを生成する。
```
public ReactiveProperty<string> ModelToViewStringTwoWay { get; }

ModelToViewStringTwoWay = model.ObserveProperty(x => x.ModelToViewStringTwoWay)
                .ToReactiveProperty()
                .AddTo(disposables);
```

## Model->View（一方通行、リスト）
### Model
ObservableCollectionを宣言する。
```
public ObservableCollection<string> ModelToViewCollection { get; }
```
### ViewModel
ModelのObservableCollectionをToReadOnlyReactiveCollection()で変換する。
```
public ReadOnlyReactiveCollection<string> ModelToViewCollection { get; }

ModelToViewCollection = model.ModelToViewCollection.ToReadOnlyReactiveCollection()
                .AddTo(disposables);
```