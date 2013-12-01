using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI.Xaml.Media;

namespace FastestPainter.DataSource.Levels
{
    using System;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Media.Imaging;

    public class Level : System.ComponentModel.INotifyPropertyChanged
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

    

    public class LevelsStoreData
    {
        private ItemCollection AtelierCollection = new ItemCollection();
        private ItemCollection BigBossCollection = new ItemCollection();
        private ItemCollection JeanLuisBaguetteCollection = new ItemCollection();
        private ItemCollection KingCollection = new ItemCollection();
        private ItemCollection BigMamaCollection = new ItemCollection();
        private ItemCollection EnigmusCollection = new ItemCollection();
        private ItemCollection BonusCollection = new ItemCollection();

        public LevelsStoreData()
        {
            //### Atelier
            Level item;
            item = new Level();
            item.Title = "Apple";
            item.SetImage("/Images/mela.png");
            AtelierCollection.Add(item);

            item = new Level();
            item.Title = "Banana";
            item.SetImage("/Images/banane.png");
            AtelierCollection.Add(item);

            item = new Level();
            item.Title = "Uva";
            item.SetImage("/Images/uva.png");
            AtelierCollection.Add(item);

            item = new Level();
            item.Title = "Cocco";
            item.SetImage("/Images/cocco.png");
            AtelierCollection.Add(item);

            item = new Level();
            item.Title = "Cherry";
            item.SetImage("/Images/ciliegie.png");
            AtelierCollection.Add(item);

            item = new Level();
            item.Title = "Lemon";
            item.SetImage("/Images/lemon.png");
            AtelierCollection.Add(item);

            //### BIG BOSS
            item = new Level();
            item.Title = "Vitruvian";
            item.SetImage("/Images/vitruvian.png");
            BigBossCollection.Add(item);

            //### JEAN LUIS BAGUETTE

            //### THE KING

            //### BIG MAMA

            //### ENIGMUS

            //### BONUS
        }

        public ItemCollection getLevels(short section){
            switch (section) {
                case 0:
                    return AtelierCollection;
                case 1:
                    return BigBossCollection;
                case 2:
                    return JeanLuisBaguetteCollection;
                case 3:
                    return KingCollection;
                case 4:
                    return BigMamaCollection;
                case 5:
                    return EnigmusCollection;
                case 6:
                    return BonusCollection;
                default:
                    return null;
            }
        }
    }

    // Workaround: data binding works best with an enumeration of objects that does not implement IList
    public class ItemCollection : IEnumerable<Object>
    {
        private System.Collections.ObjectModel.ObservableCollection<Level> itemCollection = new System.Collections.ObjectModel.ObservableCollection<Level>();

        public IEnumerator<Object> GetEnumerator()
        {
            return itemCollection.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Level item)
        {
            itemCollection.Add(item);
        }
    }
}