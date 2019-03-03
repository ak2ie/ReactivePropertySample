# ReactiveProperty�T���v��
## Model -> View�i����ʍs�j
### Model
BindableBase���p�����A�v���p�e�B�����B
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
            ModelToViewString = "�e�X�g";
        }
    }
```

### ViewModel
ObserveProperty����ReadOnlyReactiveProperty�𐶐�����B
�i����ʍs�Ȃ̂�ReadOnly�j
```
public ReadOnlyReactiveProperty<string> ModelToViewString { get; }

ModelToViewString = model.ObserveProperty(x => x.ModelToViewString)
                .ToReadOnlyReactiveProperty()
                .AddTo(disposables);
```

## Model <-> View�i�����j
### Model
BindableBase���p�����A�v���p�e�B�����B�i����ʍs�Ɠ����j
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
            ModelToViewStringTwoWay = "�e�X�g�i���������\�j";
        }
    }
```

### ViewModel
ObserveProperty����ReactiveProperty�𐶐�����B
```
public ReactiveProperty<string> ModelToViewStringTwoWay { get; }

ModelToViewStringTwoWay = model.ObserveProperty(x => x.ModelToViewStringTwoWay)
                .ToReactiveProperty()
                .AddTo(disposables);
```

## Model->View�i����ʍs�A���X�g�j
### Model
ObservableCollection��錾����B
```
public ObservableCollection<string> ModelToViewCollection { get; }
```
### ViewModel
Model��ObservableCollection��ToReadOnlyReactiveCollection()�ŕϊ�����B
```
public ReadOnlyReactiveCollection<string> ModelToViewCollection { get; }

ModelToViewCollection = model.ModelToViewCollection.ToReadOnlyReactiveCollection()
                .AddTo(disposables);
```