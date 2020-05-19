using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.AppStatics;
using TestApp.Model;
using Xamarin.Forms;

namespace TestApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var list = new ObservableCollection<Announcement>
            {
                new Announcement
                {
                    ID = 1,
                    Title = "Yedek parça siparişlerinizde %22' ye varan indirim!",
                    ImagePath = "https://image5.sahibinden.com/photos/08/54/18/x5_719085418j7p.jpg",
                    IsActive = true,
                    CreateDate = DateTime.Now,
                },
                new Announcement
                {
                    ID = 2,
                    Title = "Fren Balataları Hangi Sıklıkla Değiştirilmelidir?",
                    ImagePath = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcTJzQfduSrJ3Nh7SHzGSGrCmTnWses4AcfuRSnU7hX4y9XN4TSU&usqp=CAU",
                    IsActive = true,
                    CreateDate = DateTime.Now,
                }
            };

            DeviceHelper helper = DependencyService.Get<IDeviceHelper>().GetDevice();

            double height = 0;
            //double width = helper.ScreenWidth / 2 - 30;

            for (int m = 0; m < 6; m++)
            {
                for (int i = 0; i < list.Count; i++)
                {

                    Frame frame = new Frame
                    {
                        Padding = new Thickness(0, 0, 0, 0)
                    };

                    // Stack
                    StackLayout stack = new StackLayout
                    {
                        Margin = new Thickness(10),
                    };

                    // Image
                    Image image = new Image
                    {
                        Source = list[i].ImagePath,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand
                    };

                    // Title
                    Label title = new Label
                    {
                        Text = list[i].Title,
                        Margin = new Thickness(0, 6, 0, 0),
                        FontSize = 13
                    };

                    // Date
                    Label date = new Label
                    {
                        Text = list[i].CreateDate.ToString().Substring(0, 10), // temporary workaround
                        Margin = new Thickness(0, 6, 0, 0),
                        TextColor = Color.Gray,
                        FontSize = 11
                    };

                    stack.Children.Add(image);
                    stack.Children.Add(title);
                    stack.Children.Add(date);

                    frame.Content = stack;


                    if (i % 2 == 0)
                    {
                        stckLeft.Children.Add(frame);
                    }
                    else
                    {
                        stckRight.Children.Add(frame);

                        SizeRequest columnSizeRequest = frame.Measure(300, 400);
                        height += columnSizeRequest.Request.Height * 6;
                    }
                }
            }
            stckLeft.HeightRequest = height;
            stckRight.HeightRequest = height;

            scrList.HeightRequest = helper.ScreenHeight - 100;
            //stckParent.HeightRequest = list.Count * 100;

        }
    }
}
