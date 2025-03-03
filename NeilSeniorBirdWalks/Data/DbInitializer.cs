using NeilSeniorBirdWalks.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NeilSeniorBirdWalks.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {

            context.Database.Migrate();

            // Seed Locations
            if (!context.Locations.Any())
            {
                var northNorfolk = new Location { LocationCode = "northnorfolk", LocationName = "North Norfolk", Description = "Beautiful coastal area" };
                var westNorfolk = new Location { LocationCode = "westnorfolk", LocationName = "West Norfolk", Description = "Inland marshes and fens" };

                context.Locations.Add(northNorfolk);
                context.Locations.Add(westNorfolk);
                context.SaveChanges();
            }

            // Seed Seasons
            if (!context.Seasons.Any())
            {
                var spring = new Season { SeasonCode = "spring", SeasonName = "Spring", Description = "March to May" };
                var autumn = new Season { SeasonCode = "autumn", SeasonName = "Autumn", Description = "September to November" };
                var winter = new Season { SeasonCode = "winter", SeasonName = "Winter", Description = "December to February" };

                context.Seasons.AddRange(spring, autumn, winter);
                context.SaveChanges();
            }

            // Seed Birds
            if (!context.Birds.Any())
            {
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

                context.Birds.AddRange(birds);
                context.SaveChanges();
            }

            // Seed Tours
            if (!context.Tours.Any())
            {
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

                context.Tours.AddRange(tours);
                context.SaveChanges();
            }


            // Seed TourBirds with likelihood
            if (!context.TourBirds.Any())
            {
                var tourBirds = new List<TourBird>
                {
                    // North Norfolk Spring
                    new TourBird { TourId = context.Tours.First(t => t.Title == "Spring North Norfolk Tour").TourId, BirdId = context.Birds.First(b => b.CommonName == "Chiffchaff").BirdId, Likelihood = "Common" },
                    new TourBird { TourId = context.Tours.First(t => t.Title == "Spring North Norfolk Tour").TourId, BirdId = context.Birds.First(b => b.CommonName == "Blackcap").BirdId, Likelihood = "Common" },
                    new TourBird { TourId = context.Tours.First(t => t.Title == "Spring North Norfolk Tour").TourId, BirdId = context.Birds.First(b => b.CommonName == "Marsh Harrier").BirdId, Likelihood = "Likely" },
                    new TourBird { TourId = context.Tours.First(t => t.Title == "Spring North Norfolk Tour").TourId, BirdId = context.Birds.First(b => b.CommonName == "Avocet").BirdId, Likelihood = "Likely" },
                    new TourBird { TourId = context.Tours.First(t => t.Title == "Spring North Norfolk Tour").TourId, BirdId = context.Birds.First(b => b.CommonName == "Bittern").BirdId, Likelihood = "Occasional" },

                    // North Norfolk Autumn
                    new TourBird { TourId = context.Tours.First(t => t.Title == "Autumn North Norfolk Tour").TourId, BirdId = context.Birds.First(b => b.CommonName == "Pink-footed Goose").BirdId, Likelihood = "Common" },
                    new TourBird { TourId = context.Tours.First(t => t.Title == "Autumn North Norfolk Tour").TourId, BirdId = context.Birds.First(b => b.CommonName == "Avocet").BirdId, Likelihood = "Likely" },

                    // North Norfolk Winter
                    new TourBird { TourId = context.Tours.First(t => t.Title == "Winter North Norfolk Tour").TourId, BirdId = context.Birds.First(b => b.CommonName == "Snow Bunting").BirdId, Likelihood = "Likely" },
                    new TourBird { TourId = context.Tours.First(t => t.Title == "Winter North Norfolk Tour").TourId, BirdId = context.Birds.First(b => b.CommonName == "Pink-footed Goose").BirdId, Likelihood = "Common" },

                    // West Norfolk Spring
                    new TourBird { TourId = context.Tours.First(t => t.Title == "Spring West Norfolk Tour").TourId, BirdId = context.Birds.First(b => b.CommonName == "Nightingale").BirdId, Likelihood = "Likely" },
                    new TourBird { TourId = context.Tours.First(t => t.Title == "Spring West Norfolk Tour").TourId, BirdId = context.Birds.First(b => b.CommonName == "Common Crane").BirdId, Likelihood = "Occasional" },

                    // West Norfolk Autumn
                    
                    new TourBird { TourId = context.Tours.First(t => t.Title == "Autumn West Norfolk Tour").TourId, BirdId = context.Birds.First(b => b.CommonName == "Common Crane").BirdId, Likelihood = "Likely" },

                    // West Norfolk Winter
                    new TourBird { TourId = context.Tours.First(t => t.Title == "Winter West Norfolk Tour").TourId, BirdId = context.Birds.First(b => b.CommonName == "Whooper Swan").BirdId, Likelihood = "Common" }
                };

                context.TourBirds.AddRange(tourBirds);
                context.SaveChanges();
            }

            // Seed PageContent
            if (!context.PageContents.Any())
            {
                var pageContents = new PageContent[]
                {
                    new PageContent
                    {
                        PageType = "About",
                        Title = "About Neil's Senior Bird Walks",
                        Subtitle = "Discover Norfolk's incredible birds with expert guidance",
                        MainContent = "Welcome to Neil's Senior Bird Walks, where we specialize in guided bird watching tours for seniors across the beautiful Norfolk countryside. With over 20 years of experience, Neil brings expert knowledge, patience, and enthusiasm to every tour.",
                        MainContentImage = "/images/content/about-main.jpg",
                        SecondaryContent = "Our tours are designed with seniors in mind - comfortable pacing, accessible routes, and regular rest stops. We focus on quality experiences rather than rushing between locations. Small group sizes ensure personal attention and a better chance of observing even the most elusive species.",
                        SecondaryContentImage = "/images/content/about-secondary.jpg",
                        TertiaryContent = "Whether you're a complete beginner or an experienced birder, our tours offer something for everyone. High-quality optics are provided, and Neil is always happy to help you improve your bird identification skills. Join us to experience Norfolk's rich avian diversity in good company.",
                        TertiaryContentImage = "/images/content/about-tertiary.jpg",
                        IsPublished = true
                    },
                    new PageContent
                    {
                        PageType = "Blog",
                        Title = "Bird Watching Blog",
                        Subtitle = "Latest sightings and birding tips",
                        MainContent = "Our latest expedition to North Norfolk yielded some extraordinary sightings! The highlight was undoubtedly the pair of Marsh Harriers hunting over the reedbeds at dawn. Their graceful flight and distinctive V-shaped wing profile provided perfect viewing conditions for our group.",
                        MainContentImage = "/images/content/blog-main.jpg",
                        SecondaryContent = "Spring migration is now in full swing. Last week we spotted the first Chiffchaffs and Blackcaps of the season, their distinctive calls alerting us to their presence before they became visible. Tip: Learning bird calls can double your identification success rate, especially in woodland habitats.",
                        SecondaryContentImage = "/images/content/blog-secondary.jpg",
                        TertiaryContent = "Bird watching equipment spotlight: We've been testing the new Swarovski NL Pure binoculars on recent tours. The wider field of view and incredible edge-to-edge clarity has impressed everyone who's tried them. While they represent a significant investment, their performance in low light conditions is remarkable.",
                        TertiaryContentImage = "/images/content/blog-tertiary.jpg",
                        IsPublished = true
                    },
                    new PageContent
                    {
                        PageType = "TourInfo",
                        Title = "Tour Information",
                        Subtitle = "Everything you need to know about our bird watching tours",
                        MainContent = "Our tours run throughout the year, each season offering different bird watching opportunities. All tours include transportation from designated pickup points, expert guidance, use of professional spotting scopes, and refreshments. Group sizes are limited to 8 participants to ensure a quality experience.",
                        MainContentImage = "/images/content/tour-main.jpg",
                        SecondaryContent = "What to bring: Comfortable walking shoes, weather-appropriate clothing (layers recommended), binoculars if you have them (though we can provide these), and a camera if desired. Tours typically last 4-5 hours including breaks, covering approximately 2-3 miles of gentle walking.",
                        SecondaryContentImage = "/images/content/tour-secondary.jpg",
                        TertiaryContent = "Bookings can be made online, by phone, or email. We require a 50% deposit to secure your place, with the balance due 7 days before the tour. Cancellations made more than 14 days in advance receive a full refund. Special dietary requirements can be accommodated with advance notice.",
                        TertiaryContentImage = "/images/content/tour-tertiary.jpg",
                        IsPublished = true
                    }
                };

                context.PageContents.AddRange(pageContents);
                context.SaveChanges();
            }
        }
    }
}