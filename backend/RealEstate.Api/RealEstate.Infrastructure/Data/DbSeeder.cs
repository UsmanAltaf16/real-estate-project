using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;

namespace RealEstate.Infrastructure.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(AppDbContext db)
    {
        await db.Database.MigrateAsync();

        #region Properties Data Insert

        if (!await db.Properties.AnyAsync())
        {
            db.Properties.AddRange(
                new Property
                {
                    Title = "Modern Family Home",
                    Address = "123 Maple St, Springfield",
                    Price = 450000,
                    ListingType = "Sale",
                    Bedrooms = 4,
                    Bathrooms = 2,
                    CarSpots = 2,
                    Description = "Light-filled rooms, large backyard.",
                    ImageUrls = new() { "https://picsum.photos/seed/1/800/500" }
                },
                new Property
                {
                    Title = "City Apartment",
                    Address = "22 King Rd, Downtown",
                    Price = 2200,
                    ListingType = "Rent",
                    Bedrooms = 2,
                    Bathrooms = 1,
                    CarSpots = 1,
                    Description = "Walk to cafes and transit.",
                    ImageUrls = new() { "https://picsum.photos/seed/2/800/500" }
                },
                new Property
                {
                    Title = "Cozy Cottage",
                    Address = "4 River View, Lakeside",
                    Price = 320000,
                    ListingType = "Sale",
                    Bedrooms = 3,
                    Bathrooms = 2,
                    CarSpots = 2,
                    Description = "Quiet cul-de-sac near lake.",
                    ImageUrls = new() { "https://picsum.photos/seed/3/800/500" }
                },
                new Property
                {
                    Title = "Luxury Penthouse",
                    Address = "88 Skyline Blvd, Metropolis",
                    Price = 1200000,
                    ListingType = "Sale",
                    Bedrooms = 5,
                    Bathrooms = 4,
                    CarSpots = 3,
                    Description = "Breathtaking city views with private pool.",
                    ImageUrls = new() { "https://picsum.photos/seed/4/800/500" }
                },
                new Property
                {
                    Title = "Suburban Townhouse",
                    Address = "45 Oak Ave, Greenfield",
                    Price = 280000,
                    ListingType = "Sale",
                    Bedrooms = 3,
                    Bathrooms = 2,
                    CarSpots = 1,
                    Description = "Low-maintenance home in a family-friendly area.",
                    ImageUrls = new() { "https://picsum.photos/seed/5/800/500" }
                },
                new Property
                {
                    Title = "Beachfront Villa",
                    Address = "1 Ocean Drive, Palm Beach",
                    Price = 2500000,
                    ListingType = "Sale",
                    Bedrooms = 6,
                    Bathrooms = 5,
                    CarSpots = 4,
                    Description = "Private beach access and infinity pool.",
                    ImageUrls = new() { "https://picsum.photos/seed/6/800/500" }
                },
                new Property
                {
                    Title = "Downtown Loft",
                    Address = "300 Main St, Capital City",
                    Price = 3500,
                    ListingType = "Rent",
                    Bedrooms = 1,
                    Bathrooms = 1,
                    CarSpots = 0,
                    Description = "Open-plan loft with industrial design.",
                    ImageUrls = new() { "https://picsum.photos/seed/7/800/500" }
                },
                new Property
                {
                    Title = "Mountain Cabin",
                    Address = "12 Pine Trail, Highland",
                    Price = 180000,
                    ListingType = "Sale",
                    Bedrooms = 2,
                    Bathrooms = 1,
                    CarSpots = 1,
                    Description = "Rustic charm with modern amenities.",
                    ImageUrls = new() { "https://picsum.photos/seed/8/800/500" }
                },
                new Property
                {
                    Title = "Student Apartment",
                    Address = "55 College Ave, University Town",
                    Price = 900,
                    ListingType = "Rent",
                    Bedrooms = 1,
                    Bathrooms = 1,
                    CarSpots = 0,
                    Description = "Affordable unit close to campus.",
                    ImageUrls = new() { "https://picsum.photos/seed/9/800/500" }
                },
                new Property
                {
                    Title = "Golf Course Estate",
                    Address = "9 Fairway Lane, Eagle Hills",
                    Price = 950000,
                    ListingType = "Sale",
                    Bedrooms = 4,
                    Bathrooms = 3,
                    CarSpots = 3,
                    Description = "Panoramic golf views from every room.",
                    ImageUrls = new() { "https://picsum.photos/seed/10/800/500" }
                },
                new Property
                {
                    Title = "Modern Studio",
                    Address = "77 Market Rd, City Center",
                    Price = 1500,
                    ListingType = "Rent",
                    Bedrooms = 0,
                    Bathrooms = 1,
                    CarSpots = 0,
                    Description = "Perfect for singles or remote workers.",
                    ImageUrls = new() { "https://picsum.photos/seed/11/800/500" }
                },
                new Property
                {
                    Title = "Farmhouse Retreat",
                    Address = "23 Country Rd, Meadowville",
                    Price = 420000,
                    ListingType = "Sale",
                    Bedrooms = 5,
                    Bathrooms = 3,
                    CarSpots = 3,
                    Description = "Acreage property with stables and barn.",
                    ImageUrls = new() { "https://picsum.photos/seed/12/800/500" }
                },
                new Property
                {
                    Title = "Riverside Apartment",
                    Address = "14 Riverbank Dr, Baytown",
                    Price = 2700,
                    ListingType = "Rent",
                    Bedrooms = 2,
                    Bathrooms = 2,
                    CarSpots = 1,
                    Description = "Balcony with sunset views over the river.",
                    ImageUrls = new() { "https://picsum.photos/seed/13/800/500" }
                },
                new Property
                {
                    Title = "Country Manor",
                    Address = "100 Manor Rd, Ashford",
                    Price = 1500000,
                    ListingType = "Sale",
                    Bedrooms = 7,
                    Bathrooms = 6,
                    CarSpots = 5,
                    Description = "Grand estate with landscaped gardens.",
                    ImageUrls = new() { "https://picsum.photos/seed/14/800/500" }
                },
                new Property
                {
                    Title = "Budget Studio",
                    Address = "10 Elm St, Midcity",
                    Price = 800,
                    ListingType = "Rent",
                    Bedrooms = 0,
                    Bathrooms = 1,
                    CarSpots = 0,
                    Description = "Compact living space in central location.",
                    ImageUrls = new() { "https://picsum.photos/seed/15/800/500" }
                },
                new Property
                {
                    Title = "Lake House",
                    Address = "5 Lakeshore Rd, Clearwater",
                    Price = 600000,
                    ListingType = "Sale",
                    Bedrooms = 4,
                    Bathrooms = 3,
                    CarSpots = 2,
                    Description = "Dock and boathouse included.",
                    ImageUrls = new() { "https://picsum.photos/seed/16/800/500" }
                },
                new Property
                {
                    Title = "Industrial Warehouse Loft",
                    Address = "120 Industrial Ave, Urban District",
                    Price = 3800,
                    ListingType = "Rent",
                    Bedrooms = 2,
                    Bathrooms = 2,
                    CarSpots = 1,
                    Description = "Unique space with exposed brick and beams.",
                    ImageUrls = new() { "https://picsum.photos/seed/17/800/500" }
                },
                new Property
                {
                    Title = "Tiny Home",
                    Address = "Lot 3 Maple Grove, Smallville",
                    Price = 75000,
                    ListingType = "Sale",
                    Bedrooms = 1,
                    Bathrooms = 1,
                    CarSpots = 1,
                    Description = "Minimalist lifestyle, big on style.",
                    ImageUrls = new() { "https://picsum.photos/seed/18/800/500" }
                },
                new Property
                {
                    Title = "Historic Brownstone",
                    Address = "9 Heritage St, Oldtown",
                    Price = 980000,
                    ListingType = "Sale",
                    Bedrooms = 5,
                    Bathrooms = 3,
                    CarSpots = 1,
                    Description = "Restored period details with modern kitchen.",
                    ImageUrls = new() { "https://picsum.photos/seed/19/800/500" }
                },
                new Property
                {
                    Title = "Corporate Rental Apartment",
                    Address = "200 Executive Blvd, Business Bay",
                    Price = 5000,
                    ListingType = "Rent",
                    Bedrooms = 3,
                    Bathrooms = 2,
                    CarSpots = 2,
                    Description = "Fully furnished, short-term corporate lease.",
                    ImageUrls = new() { "https://picsum.photos/seed/20/800/500" }
                }
            );

            await db.SaveChangesAsync();
        }

        #endregion
    }
}
