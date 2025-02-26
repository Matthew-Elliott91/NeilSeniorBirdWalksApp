using System.Threading.Tasks;

namespace NeilSeniorBirdWalks.Services
{
    public class TourService
    {
        public async Task<TourDetail> GetTourDetailsAsync(string location, string season)
        {
            // In a real app, this would fetch from a database
            await Task.Delay(300); // Simulate network delay

            // Example data
            return new TourDetail
            {
                Title = $"{season} {GetLocationName(location)} Tour",
                Description = $"Experience the beauty of {GetLocationName(location)} during {season}. This guided tour takes you through the region's prime birdwatching spots.",
                Birds = GetBirdsForLocationAndSeason(location, season)
            };
        }

        private string GetLocationName(string location) => location.ToLower() switch
        {
            "northnorfolk" => "North Norfolk",
            "westnorfolk" => "West Norfolk",
            _ => location
        };

        private string[] GetBirdsForLocationAndSeason(string location, string season)
        {
            // This would typically come from a database
            if (location.ToLower() == "northnorfolk")
            {
                return season.ToLower() switch
                {
                    "spring" => new[] { "Chiffchaff", "Blackcap", "Marsh Harrier", "Avocet", "Bittern" },
                    "summer" => new[] { "Little Tern", "Common Tern", "Swift", "Cuckoo", "Reed Warbler" },
                    "autumn" => new[] { "Brent Goose", "Pink-footed Goose", "Yellow-browed Warbler", "Redwing", "Fieldfare" },
                    "winter" => new[] { "Snow Bunting", "Shore Lark", "Long-tailed Duck", "Common Scoter", "Red-throated Diver" },
                    _ => new[] { "Various local birds" }
                };
            }
            else if (location.ToLower() == "westnorfolk")
            {
                return season.ToLower() switch
                {
                    "spring" => new[] { "Nightingale", "Garden Warbler", "Hobby", "Little Ringed Plover", "Common Crane" },
                    "summer" => new[] { "Spotted Flycatcher", "Turtle Dove", "Bearded Tit", "Marsh Harrier", "Bittern" },
                    "autumn" => new[] { "Waxwing", "Redstart", "Wheatear", "Brambling", "Common Crane" },
                    "winter" => new[] { "Whooper Swan", "Bewick's Swan", "Hen Harrier", "Short-eared Owl", "Rough-legged Buzzard" },
                    _ => new[] { "Various local birds" }
                };
            }

            return new[] { "Various local birds", "Seasonal migrants", "Coastal species" };
        }
    }

    public class TourDetail
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string[] Birds { get; set; }
    }
}
