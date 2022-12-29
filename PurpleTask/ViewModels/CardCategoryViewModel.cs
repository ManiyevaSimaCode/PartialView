using PurpleTask.Models;

namespace PurpleTask.ViewModels
{
    public class CardCategoryViewModel
    {
        public List<Card> Cards { get; set; }
        public List<Category> Categories { get; set; }
        public List<Slider>Sliders { get; set; }
    }
}
