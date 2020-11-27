
namespace ILanguage.API.Resources
{
    public class ReviewResource
    {

        public int Id { get; set; }

        public int Starts { get; set; }

        public string Description { get; set; }

        public UserResource User { get; set; }

    }

}
