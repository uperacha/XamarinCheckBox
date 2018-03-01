using Xamarin.Forms;

namespace CustomCheckBoxSample
{
    public class Checkbox : Frame
    {
        public static readonly BindableProperty EmptyImageSourceProperty =
            BindableProperty.Create("EmptyImageSource", typeof(ImageSource), typeof(Checkbox), default(ImageSource),
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanging: (bindable, oldValue, newValue) =>
                {
                    Checkbox _ = (Checkbox)bindable;
                    _.EmptyImageSource = (ImageSource)newValue;

                    _.ImageSource = _.EmptyImageSource;
                });

        public static readonly BindableProperty FilledImageSourceProperty =
            BindableProperty.Create("FilledImageSource", typeof(ImageSource), typeof(Checkbox), default(ImageSource),
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanging: (bindable, oldValue, newValue) =>
                {
                    Checkbox _ = (Checkbox)bindable;
                    _.FilledImageSource = (ImageSource)newValue;
                });

        public static readonly BindableProperty IsCheckedProperty =
            BindableProperty.Create("IsChecked", typeof(bool), typeof(Checkbox), default(bool),
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanging: (bindable, oldValue, newValue) =>
                {
                    Checkbox _ = (Checkbox)bindable;
                    _.IsChecked = (bool)newValue;
                });

        private bool _isChecked { get; set; }
        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }
            set
            {
                this._isChecked = value;

                if (_isChecked)
                    this.ImageSource = FilledImageSource;
                else
                    this.ImageSource = EmptyImageSource;
            }
        }
        public ImageSource ImageSource
        {
            get
            {
                return this.Image != null ? this.Image.Source : string.Empty;
            }
            set
            {
                if (this.Image != null)
                {
                    this.Image.Source = value;
                }
            }
        }
        public ImageSource EmptyImageSource { get; set; }
        public ImageSource FilledImageSource { get; set; }
        protected Image Image { get; private set; }
        public Checkbox()
        {

            this.BuildControl();
        }
        private void BuildControl()
        {
            this.Padding = 3;
            this.Margin = 0;
            this.CornerRadius = 0;
            this.WidthRequest = 20;
            this.HeightRequest = 20;
            this.HasShadow = false;


            this.Image = new Image
            {
                Aspect = Aspect.AspectFill,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            this.Content = this.Image;
        }
    }
}
