using NeilSeniorBirdWalks.Models;
using System.Linq;

namespace NeilSeniorBirdWalks.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Locations.Any())
                return;

            // Seed Locations
            var northNorfolk = new Location { LocationCode = "northnorfolk", LocationName = "North Norfolk", Description = "Beautiful coastal area" };
            var westNorfolk = new Location { LocationCode = "westnorfolk", LocationName = "West Norfolk", Description = "Inland marshes and fens" };
            if (!context.Locations.Any(l => l.LocationCode == northNorfolk.LocationCode))
                context.Locations.Add(northNorfolk);
            if (!context.Locations.Any(l => l.LocationCode == westNorfolk.LocationCode))
                context.Locations.Add(westNorfolk);
            context.SaveChanges();

            // Seed Seasons
            var spring = new Season { SeasonCode = "spring", SeasonName = "Spring", Description = "March to May" };
            var summer = new Season { SeasonCode = "summer", SeasonName = "Summer", Description = "June to August" };
            var autumn = new Season { SeasonCode = "autumn", SeasonName = "Autumn", Description = "September to November" };
            var winter = new Season { SeasonCode = "winter", SeasonName = "Winter", Description = "December to February" };
            if (!context.Seasons.Any(s => s.SeasonCode == spring.SeasonCode))
                context.Seasons.Add(spring);
            if (!context.Seasons.Any(s => s.SeasonCode == summer.SeasonCode))
                context.Seasons.Add(summer);
            if (!context.Seasons.Any(s => s.SeasonCode == autumn.SeasonCode))
                context.Seasons.Add(autumn);
            if (!context.Seasons.Any(s => s.SeasonCode == winter.SeasonCode))
                context.Seasons.Add(winter);
            context.SaveChanges();

            // Seed Birds
            var birds = new Bird[]
            {
                new Bird { CommonName = "Chiffchaff", Description = "Small olive-brown warbler with a distinctive song", ImageUrl = "/images/birds/chiffchaff.jpg" },
                new Bird { CommonName = "Blackcap", Description = "Gray warbler with distinctive black (male) or rusty-brown (female) cap", ImageUrl = "/images/birds/blackcap.jpg" },
                new Bird { CommonName = "Marsh Harrier", Description = "Large raptor that glides low over reedbeds", ImageUrl = "/images/birds/marsh-harrier.jpg" },
                new Bird { CommonName = "Avocet", Description = "Elegant black and white wader with an upturned bill", ImageUrl = "/images/birds/avocet.jpg" },
                new Bird { CommonName = "Bittern", Description = "Secretive brown heron with booming call", ImageUrl = "/images/birds/bittern.jpg" },
                new Bird { CommonName = "Little Tern", Description = "Small seabird with yellow bill and white forehead", ImageUrl = "/images/birds/little-tern.jpg" },
                new Bird { CommonName = "Swift", Description = "Fast-flying aerial bird with scythe-shaped wings", ImageUrl = "/images/birds/swift.jpg" },
                new Bird { CommonName = "Pink-footed Goose", Description = "Migratory goose with pink legs and feet", ImageUrl = "/images/birds/pink-footed-goose.jpg" },
                new Bird { CommonName = "Snow Bunting", Description = "Winter visitor with white plumage and black markings", ImageUrl = "/images/birds/snow-bunting.jpg" },
                new Bird { CommonName = "Nightingale", Description = "Plain brown bird with an extraordinary song", ImageUrl = "/images/birds/nightingale.jpg" },
                new Bird { CommonName = "Turtle Dove", Description = "Declining dove with beautiful tortoiseshell pattern", ImageUrl = "/images/birds/turtle-dove.jpg" },
                new Bird { CommonName = "Common Crane", Description = "Tall gray bird with dramatic courtship displays", ImageUrl = "/images/birds/common-crane.jpg" },
                new Bird { CommonName = "Bearded Tit", Description = "Small, reed-dwelling bird with long tail", ImageUrl = "/images/birds/bearded-tit.jpg" },
                new Bird { CommonName = "Whooper Swan", Description = "Large white swan with yellow and black bill", ImageUrl = "/images/birds/whooper-swan.jpg" }
            };
            foreach (var bird in birds)
            {
                if (!context.Birds.Any(b => b.CommonName == bird.CommonName))
                    context.Birds.Add(bird);
            }
            context.SaveChanges();

            // Seed Tours
            var tours = new Tour[]
            {
                new Tour {
                    LocationId = context.Locations.First(l => l.LocationCode == "northnorfolk").LocationId,
                    SeasonId = context.Seasons.First(s => s.SeasonCode == "spring").SeasonId,
                    Title = "Spring North Norfolk Tour",
                    Description = "Experience the beauty of North Norfolk during spring. This guided tour takes you through the region's prime birdwatching spots.",
                    InfoHeadline = "Spring Migration Special",
                    InfoText = "Spring in North Norfolk brings vibrant wildflowers and the return of migratory birds. Perfect for spotting newly arrived species.",
                    InfoImageUrl = "/images/tours/northnorfolk-spring.jpg",
                    Price = 45.00m,
                    Duration = 240
                },
                new Tour {
                    LocationId = context.Locations.First(l => l.LocationCode == "northnorfolk").LocationId,
                    SeasonId = context.Seasons.First(s => s.SeasonCode == "summer").SeasonId,
                    Title = "Summer North Norfolk Tour",
                    Description = "Experience the beauty of North Norfolk during summer. This guided tour takes you through the region's prime birdwatching spots.",
                    InfoHeadline = "Summer Breeding Birds",
                    InfoText = "Summer offers the longest daylight hours for birdwatching along North Norfolk's beautiful coastline and marshes.",
                    InfoImageUrl = "/images/tours/northnorfolk-summer.jpg",
                    Price = 40.00m,
                    Duration = 210
                },
                new Tour {
                    LocationId = context.Locations.First(l => l.LocationCode == "northnorfolk").LocationId,
                    SeasonId = context.Seasons.First(s => s.SeasonCode == "autumn").SeasonId,
                    Title = "Autumn North Norfolk Tour",
                    Description = "Experience the beauty of North Norfolk during autumn. This guided tour takes you through the region's prime birdwatching spots.",
                    InfoHeadline = "Autumn Migration Spectacle",
                    InfoText = "Autumn migration brings thousands of geese and ducks to North Norfolk's reserves. The evening murmuration displays are spectacular.",
                    InfoImageUrl = "/images/tours/northnorfolk-autumn.jpg",
                    Price = 50.00m,
                    Duration = 240
                },
                new Tour {
                    LocationId = context.Locations.First(l => l.LocationCode == "northnorfolk").LocationId,
                    SeasonId = context.Seasons.First(s => s.SeasonCode == "winter").SeasonId,
                    Title = "Winter North Norfolk Tour",
                    Description = "Experience the beauty of North Norfolk during winter. This guided tour takes you through the region's prime birdwatching spots.",
                    InfoHeadline = "Winter Coastal Specials",
                    InfoText = "Winter transforms North Norfolk into a haven for northern visitors like Snow Buntings and Shore Larks along the beaches.",
                    InfoImageUrl = "/images/tours/northnorfolk-winter.jpg",
                    Price = 55.00m,
                    Duration = 210
                },
                new Tour {
                    LocationId = context.Locations.First(l => l.LocationCode == "westnorfolk").LocationId,
                    SeasonId = context.Seasons.First(s => s.SeasonCode == "spring").SeasonId,
                    Title = "Spring West Norfolk Tour",
                    Description = "Experience the beauty of West Norfolk during spring. This guided tour takes you through the region's prime birdwatching spots.",
                    InfoHeadline = "Spring Woodland Chorus",
                    InfoText = "Spring in West Norfolk features dawn chorus walks and the chance to hear rare Nightingales in The Fens and woodlands.",
                    InfoImageUrl = "/images/tours/westnorfolk-spring.jpg",
                    Price = 45.00m,
                    Duration = 240
                },
                new Tour {
                    LocationId = context.Locations.First(l => l.LocationCode == "westnorfolk").LocationId,
                    SeasonId = context.Seasons.First(s => s.SeasonCode == "summer").SeasonId,
                    Title = "Summer West Norfolk Tour",
                    Description = "Experience the beauty of West Norfolk during summer. This guided tour takes you through the region's prime birdwatching spots.",
                    InfoHeadline = "Summer Wetland Specials",
                    InfoText = "Summer in West Norfolk is ideal for observing breeding waders and rare wetland species in the Ouse Washes.",
                    InfoImageUrl = "/images/tours/westnorfolk-summer.jpg",
                    Price = 40.00m,
                    Duration = 180
                },
                new Tour {
                    LocationId = context.Locations.First(l => l.LocationCode == "westnorfolk").LocationId,
                    SeasonId = context.Seasons.First(s => s.SeasonCode == "autumn").SeasonId,
                    Title = "Autumn West Norfolk Tour",
                    Description = "Experience the beauty of West Norfolk during autumn. This guided tour takes you through the region's prime birdwatching spots.",
                    InfoHeadline = "Autumn Swan Arrivals",
                    InfoText = "Autumn in West Norfolk brings impressive gatherings of swans and other waterfowl to the Welney Wetland Centre.",
                    InfoImageUrl = "/images/tours/westnorfolk-autumn.jpg",
                    Price = 50.00m,
                    Duration = 240
                },
                new Tour {
                    LocationId = context.Locations.First(l => l.LocationCode == "westnorfolk").LocationId,
                    SeasonId = context.Seasons.First(s => s.SeasonCode == "winter").SeasonId,
                    Title = "Winter West Norfolk Tour",
                    Description = "Experience the beauty of West Norfolk during winter. This guided tour takes you through the region's prime birdwatching spots.",
                    InfoHeadline = "Winter Raptor Watching",
                    InfoText = "Winter offers dramatic raptor displays across West Norfolk's open landscapes, with Hen Harriers and Short-eared Owls.",
                    InfoImageUrl = "/images/tours/westnorfolk-winter.jpg",
                    Price = 55.00m,
                    Duration = 210
                }
            };
            foreach (var tour in tours)
            {
                if (!context.Tours.Any(t => t.Title == tour.Title))
                    context.Tours.Add(tour);
            }
            context.SaveChanges();

            // Seed TourBirds with likelihood
            var tourBirds = new List<TourBird>
            {
                // North Norfolk Spring
                new TourBird { TourId = context.Tours.First(t => t.Title == "Spring North Norfolk Tour").TourId, BirdId = context.Birds.First(b => b.CommonName == "Chiffchaff").BirdId, Likelihood = "Common" },
                new TourBird { TourId = context.Tours.First(t => t.Title == "Spring North Norfolk Tour").TourId, BirdId = context.Birds.First(b => b.CommonName == "Blackcap").BirdId, Likelihood = "Common" },
                new TourBird { TourId = context.Tours.First(t => t.Title == "Spring North Norfolk Tour").TourId, BirdId = context.Birds.First(b => b.CommonName == "Marsh Harrier").BirdId, Likelihood = "Likely" },
                new TourBird { TourId = context.Tours.First(t => t.Title == "Spring North Norfolk Tour").TourId, BirdId = context.Birds.First(b => b.CommonName == "Avocet").BirdId, Likelihood = "Likely" },
                new TourBird { TourId = context.Tours.First(t => t.Title == "Spring North Norfolk Tour").TourId, BirdId = context.Birds.First(b => b.CommonName == "Bittern").BirdId, Likelihood = "Occasional" },

                // North Norfolk Summer
                new TourBird { TourId = context.Tours.First(t => t.Title == "Summer North Norfolk Tour").TourId, BirdId = context.Birds.First(b => b.CommonName == "Little Tern").BirdId, Likelihood = "Likely" },
                new TourBird { TourId = context.Tours.First(t => t.Title == "Summer North Norfolk Tour").TourId, BirdId = context.Birds.First(b => b.CommonName == "Swift").BirdId, Likelihood = "Common" },
                new TourBird { TourId = context.Tours.First(t => t.Title == "Summer North Norfolk Tour").TourId, BirdId = context.Birds.First(b => b.CommonName == "Marsh Harrier").BirdId, Likelihood = "Common" },
                new TourBird { TourId = context.Tours.First(t => t.Title == "Summer North Norfolk Tour").TourId, BirdId = context.Birds.First(b => b.CommonName == "Bittern").BirdId, Likelihood = "Occasional" },

                // North Norfolk Autumn
                new TourBird { TourId = context.Tours.First(t => t.Title == "Autumn North Norfolk Tour").TourId, BirdId = context.Birds.First(b => b.CommonName == "Pink-footed Goose").BirdId, Likelihood = "Common" },
                new TourBird { TourId = context.Tours.First(t => t.Title == "Autumn North Norfolk Tour").TourId, BirdId = context.Birds.First(b => b.CommonName == "Avocet").BirdId, Likelihood = "Likely" },

                // North Norfolk Winter
                new TourBird { TourId = context.Tours.First(t => t.Title == "Winter North Norfolk Tour").TourId, BirdId = context.Birds.First(b => b.CommonName == "Snow Bunting").BirdId, Likelihood = "Likely" },
                new TourBird { TourId = context.Tours.First(t => t.Title == "Winter North Norfolk Tour").TourId, BirdId = context.Birds.First(b => b.CommonName == "Pink-footed Goose").BirdId, Likelihood = "Common" },

                // West Norfolk Spring
                new TourBird { TourId = context.Tours.First(t => t.Title == "Spring West Norfolk Tour").TourId, BirdId = context.Birds.First(b => b.CommonName == "Nightingale").BirdId, Likelihood = "Likely" },
                new TourBird { TourId = context.Tours.First(t => t.Title == "Spring West Norfolk Tour").TourId, BirdId = context.Birds.First(b => b.CommonName == "Common Crane").BirdId, Likelihood = "Occasional" },

                // West Norfolk Summer
                new TourBird { TourId = context.Tours.First(t => t.Title == "Summer West Norfolk Tour").TourId, BirdId = context.Birds.First(b => b.CommonName == "Turtle Dove").BirdId, Likelihood = "Occasional" },
                new TourBird { TourId = context.Tours.First(t => t.Title == "Summer West Norfolk Tour").TourId, BirdId = context.Birds.First(b => b.CommonName == "Bearded Tit").BirdId, Likelihood = "Likely" },

                // West Norfolk Autumn
                new TourBird { TourId = context.Tours.First(t => t.Title == "Autumn West Norfolk Tour").TourId, BirdId = context.Birds.First(b => b.CommonName == "Common Crane").BirdId, Likelihood = "Likely" },

                // West Norfolk Winter
                new TourBird { TourId = context.Tours.First(t => t.Title == "Winter West Norfolk Tour").TourId, BirdId = context.Birds.First(b => b.CommonName == "Whooper Swan").BirdId, Likelihood = "Common" },
            };
            foreach (var tourBird in tourBirds)
            {
                if (!context.TourBirds.Any(tb => tb.TourId == tourBird.TourId && tb.BirdId == tourBird.BirdId))
                    context.TourBirds.Add(tourBird);
            }
            context.SaveChanges();
        }
    }
}
