using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI.Xaml.Media;

namespace FastestPainter.DataSource
{
    using System;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Media.Imaging;

    public class Section : System.ComponentModel.INotifyPropertyChanged
    {
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        private string _Title = string.Empty;
        public string Title
        {
            get
            {
                return this._Title;
            }

            set
            {
                if (this._Title != value)
                {
                    this._Title = value;
                    this.OnPropertyChanged("Title");
                }
            }
        }

        private ushort _Index = 0;
        public ushort Index
        {
            get
            {
                return this._Index;
            }

            set
            {
                if (this._Index != value)
                {
                    this._Index = value;
                    this.OnPropertyChanged("Index");
                }
            }
        }

        private ImageSource _Image = null;
        public ImageSource Image
        {
            get
            {
                return this._Image;
            }

            set
            {
                if (this._Image != value)
                {
                    this._Image = value;
                    this.OnPropertyChanged("Image");
                }
            }
        }

        public void SetImage(String path)
        {
            Image = new BitmapImage(new Uri("ms-appx:"+path));
        }

    }

    

    public class SectionsStoreData
    {
        private ItemCollection Collection = new ItemCollection();

        public SectionsStoreData()
        {
            Section item;
            item = new Section();
            item.Index = 1;
            item.Title = "Big Boss";
            item.SetImage("/Images/sec1presentation.png");
            Collection.Add(item);

            item = new Section();
            item.Index = 2;
            item.Title = "Jean Luis Baguette";
            item.SetImage("/Images/sec2presentation.png");
            Collection.Add(item);

            item = new Section();
            item.Index = 3;
            item.Title = "The King";
            item.SetImage("/Images/sec3presentation.png");
            Collection.Add(item);

            item = new Section();
            item.Index = 4;
            item.Title = "Big Mama";
            item.SetImage("/Images/sec4presentation.png");
            Collection.Add(item);

            item = new Section();
            item.Index = 5;
            item.Title = "Enigmus";
            item.SetImage("/Images/sec5presentation.png");
            Collection.Add(item);

            item = new Section();
            item.Index = 6;
            item.Title = "BONUS";
            item.SetImage("/Images/bonuspresentation.png");
            Collection.Add(item);
        }

        public ItemCollection getSections(){
            return Collection;
        }
    }

    // Workaround: data binding works best with an enumeration of objects that does not implement IList
    public class ItemCollection : IEnumerable<Object>
    {
        private System.Collections.ObjectModel.ObservableCollection<Section> itemCollection = new System.Collections.ObjectModel.ObservableCollection<Section>();

        public IEnumerator<Object> GetEnumerator()
        {
            return itemCollection.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Section item)
        {
            itemCollection.Add(item);
        }
    }
}