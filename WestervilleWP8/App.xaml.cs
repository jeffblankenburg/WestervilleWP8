using System;
using System.Diagnostics;
using System.Resources;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WestervilleWP8.Resources;
using Microsoft.Phone.Tasks;
using System.Collections.Generic;
using System.Device.Location;

namespace WestervilleWP8
{
    public partial class App : Application
    {
        /// <summary>
        /// Provides easy access to the root frame of the Phone Application.
        /// </summary>
        /// <returns>The root frame of the Phone Application.</returns>
        public static PhoneApplicationFrame RootFrame { get; private set; }
        public static List<RecreationItem> RecreationItems = new List<RecreationItem>();
        public static List<School> Schools = new List<School>();
        public static List<DiningItem> DiningItems = new List<DiningItem>();
        

        /// <summary>
        /// Constructor for the Application object.
        /// </summary>
        public App()
        {
            // Global handler for uncaught exceptions.
            UnhandledException += Application_UnhandledException;

            // Standard XAML initialization
            InitializeComponent();

            // Phone-specific initialization
            InitializePhoneApplication();

            // Language display initialization
            InitializeLanguage();

            // Show graphics profiling information while debugging.
            if (Debugger.IsAttached)
            {
                // Display the current frame rate counters.
                //Application.Current.Host.Settings.EnableFrameRateCounter = true;

                // Show the areas of the app that are being redrawn in each frame.
                //Application.Current.Host.Settings.EnableRedrawRegions = true;

                // Enable non-production analysis visualization mode,
                // which shows areas of a page that are handed off to GPU with a colored overlay.
                //Application.Current.Host.Settings.EnableCacheVisualization = true;

                // Prevent the screen from turning off while under the debugger by disabling
                // the application's idle detection.
                // Caution:- Use this under debug mode only. Application that disables user idle detection will continue to run
                // and consume battery power when the user is not using the phone.
                PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
            }

        }

        // Code to execute when the application is launching (eg, from Start)
        // This code will not execute when the application is reactivated
        private void Application_Launching(object sender, LaunchingEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            Schools.Add(new School { Name = "Alcott Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/1"), Location = new GeoCoordinate(40.156598, -82.90424), StreetAddress = "", ImageName = "Assets/Schools/ele_alcott.jpg", IconName="school" });
            Schools.Add(new School { Name = "Annehurst Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/2"), Location = new GeoCoordinate(40.125258, -82.9614592), StreetAddress = "", ImageName = "Assets/Schools/ele_annehurst.jpg", IconName = "school" });
            Schools.Add(new School { Name = "Cherrington Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/4"), Location = new GeoCoordinate(40.114384, -82.907953), StreetAddress = "", ImageName = "Assets/Schools/ele_cherrington.jpg", IconName = "school" });
            Schools.Add(new School { Name = "Emerson Magnet School", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/10"), Location = new GeoCoordinate(40.127319, -82.928815), StreetAddress = "", ImageName = "Assets/Schools/ele_emerson.jpg", IconName = "school" });
            Schools.Add(new School { Name = "Fouse Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/11"), Location = new GeoCoordinate(40.1697843, -82.9107486), StreetAddress = "", ImageName = "Assets/Schools/ele_fouse.jpg", IconName = "school" });
            Schools.Add(new School { Name = "Hanby Magnet", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/14"), Location = new GeoCoordinate(40.124451, -82.930546), StreetAddress = "", ImageName = "Assets/Schools/ele_hanby.jpg", IconName = "school" });
            Schools.Add(new School { Name = "Hawthorne Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/16"), Location = new GeoCoordinate(40.079516, -82.9346), StreetAddress = "", ImageName = "Assets/Schools/ele_hawthorne.jpg", IconName = "school" });
            Schools.Add(new School { Name = "Huber Ridge Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/17"), Location = new GeoCoordinate(40.0911929, -82.918261), StreetAddress = "", ImageName = "Assets/Schools/ele_huberridge.jpg", IconName = "school" });
            Schools.Add(new School { Name = "Mark Twain Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/19"), Location = new GeoCoordinate(40.119239, -82.902072), StreetAddress = "", ImageName = "Assets/Schools/ele_marktwain.jpg", IconName = "school" });
            Schools.Add(new School { Name = "McVay Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/20"), Location = new GeoCoordinate(40.1157704, -82.894139), StreetAddress = "", ImageName = "Assets/Schools/ele_mcvay.jpg", IconName = "school" });
            Schools.Add(new School { Name = "Pointview Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/21"), Location = new GeoCoordinate(40.1061089, -82.912998), StreetAddress = "", ImageName = "Assets/Schools/ele_pointview.jpg", IconName = "school" });
            Schools.Add(new School { Name = "Robert Frost Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/22"), Location = new GeoCoordinate(40.1337055, -82.9015901), StreetAddress = "", ImageName = "Assets/Schools/ele_robertfrost.jpg", IconName = "school" });
            Schools.Add(new School { Name = "Whittier Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/23"), Location = new GeoCoordinate(40.122439, -82.924392), StreetAddress = "", ImageName = "Assets/Schools/ele_whittier.jpg", IconName = "school" });
            Schools.Add(new School { Name = "Wilder Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/24"), Location = new GeoCoordinate(40.088535, -82.904195), StreetAddress = "", ImageName = "Assets/Schools/ele_wilder.jpg", IconName = "school" });

            Schools.Add(new School { Name = "Blendon Middle School", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/25"), Location = new GeoCoordinate(40.119526, -82.922496), StreetAddress = "", ImageName = "Assets/Schools/ms_blendon.jpg", IconName = "school" });
            Schools.Add(new School { Name = "Genoa Middle School", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/26"), Location = new GeoCoordinate(40.1677173, -82.9123294), StreetAddress = "", ImageName = "Assets/Schools/ms_genoa.jpg", IconName = "school" });
            Schools.Add(new School { Name = "Heritage Middle School", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/27"), Location = new GeoCoordinate(40.1356107, -82.902453), StreetAddress = "", ImageName = "Assets/Schools/ms_heritage.jpg", IconName = "school" });
            Schools.Add(new School { Name = "Walnut Springs Middle School", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/28"), Location = new GeoCoordinate(40.122377, -82.900039), StreetAddress = "", ImageName = "Assets/Schools/ms_walnutsprings.jpg", IconName = "school" });

            Schools.Add(new School { Name = "Westerville South High School", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/31"), Location = new GeoCoordinate(40.119015, -82.923719), StreetAddress = "", ImageName = "Assets/Schools/hs_south.jpg", IconName="school" });
            Schools.Add(new School { Name = "Westerville North High School", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/30"), Location = new GeoCoordinate(40.134544, -82.898109), StreetAddress = "", ImageName = "Assets/Schools/hs_north.jpg", IconName="school" });
            Schools.Add(new School { Name = "Westerville Central High School", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/29"), Location = new GeoCoordinate(40.154286, -82.903701), StreetAddress = "", ImageName = "Assets/Schools/hs_central.jpg", IconName="school" });
            
            RecreationItems.Add(new RecreationItem { Name = "Alum Creek Park North", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=278"), Location = new GeoCoordinate(40.124775, -82.939911), StreetAddress = "221 W. Main St.", ImageName="Assets/Recreation/alumcreekparknorth.jpg", IconName = "park", Description = "Situated along Alum Creek, this 12-acre Community Park holds a special place in Westerville’s history as the City’s first park. Alum Creek Park North is most recognized for housing the City’s Rotary Amphitheater. The Westerville Rotary Amphitheater was renovated in 2000 in part due to a generous donation from the Noon Rotary and the citizen-driven PROS 2000 Open Space Plan. The Amphitheater is home to the Sounds of Summer Concert Series offering a variety of entertainment to the Westerville Community June - August. The park also provides playgrounds, basketball court, baseball field, restrooms and shelter house.", Acreage = 11.93, AcquiredYear = 1934, DevelopedYear = 1935, Amenities = "Westerville rotary Amphitheater, electrical Outlets, 1 Ball diamond, 1 lighted Basketball court, 1 Sand volleyball court, Playground: (2-5 year old) with swings, , (6-12 year old) with swings, train, sand box, 3 drinking Fountains, Bike/leisure Path, emergency call Out, Fishing, 15 Benches, Flagpole, nature Area: river Front, lightning Prediction System, Picnic Area, Water Feature: Alum creek, log cabin (Scout House), concession Building" });
            RecreationItems.Add(new RecreationItem { Name = "Alum Creek Park South", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=276"), Location = new GeoCoordinate(40.1131334, -82.936166), StreetAddress = "535 Park Meadow Rd.", IconName = "park", Description = "Alum Creek South Park is the place in Westerville where extreme sports enthusiasts can let loose. The BMX/Skateboard Park in Alum Creek South Park was dedicated in 2006. The park was designed with the assistance of a youth citizen committee and was made possible by funding from PROS 2000, a grant from NatureWorks and from donations in memory of Matt Sloane, “Skate for Life”. The BMX/Skateboard Park features a 1,150 foot long BMX Track with 22 jumps and four banked turns. The Skate Park is approximately 12,000 square feet and includes quarter pipes, planter boxes, a pyramid, banked ramps and a bowl. The park also provides bike paths, open sports fields, and twin pyramidal climbing nets.", AcquiredYear = 1951, DevelopedYear = 2004, Acreage = 30.377 });
            RecreationItems.Add(new RecreationItem { Name = "Brooksedge Bark Park", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=273"), Location = new GeoCoordinate(40.107341, -82.936598), StreetAddress = "708 Park Meadow Rd.", IconName = "dog", Description = "The Bark Park at Brooksedge Park offers Westerville’s pet owners the opportunity to exercise and socialize their dogs in a secure environment. Providing four-acres of space where people and pets can happily co-exist benefits the health and well-being of our four-legged family members and enhances to the quality of life in our community. The park features two large dog areas and a small dog area, a gated vestibule for security, dog fountain and hydrants, ADA access, and activity stations.", Acreage = 3.954, AcquiredYear = 1985, DevelopedYear = 2005 });
            RecreationItems.Add(new RecreationItem { Name = "Ernest Cherrington Park", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=272"), Location = new GeoCoordinate(40.116954, -82.936974), StreetAddress = "231 Hiawatha Ave.", IconName = "park", Description = "Named after a prominent Ohio Anti-Saloon League member, Ernest Cherrington Park is situated along the banks of Alum Creek, the 18-acre park provides Westerville’s garden enthusiasts a place to call their own. The community garden gives those who wish garden, but lack the space or property to do so the opportunity to cultivate their own healthy organic food. Alum Creek and the surrounding woodlands and nature paths provide a serene and quite backdrop to the community gardens." });
            RecreationItems.Add(new RecreationItem { Name = "Hanby Park", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=268"), Location = new GeoCoordinate(40.123428, -82.92665), StreetAddress = "115 E. Park St.", IconName = "park", Description = "Located in the heart of Westerville, Hanby Park is home to the Presidential Oak Grove, a tribute to Presidents from the state of Ohio. Also located at Hanby Park is the Westerville Legacy Train Depot, a shelter that provides a place for travelers along the Ohio-Erie Trail to stop and relax or enjoy a short side-trip to Uptown Westerville for shopping or dining. The Depot was built in 2012 and houses a fireplace, restrooms, bike hub and racks, bike lockers a picnic area and playground.", Acreage = 3.91, AcquiredYear = 1994 });
            RecreationItems.Add(new RecreationItem { Name = "Hannah Mayne Park", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=266"), Location = new GeoCoordinate(40.120614, -82.93224), StreetAddress = "55 Glenwood Ave.", IconName = "park", Description = "This quiet park, located just south of Uptown Westerville is a hidden jewel. Visitors can enjoy a playground with dueling slides, a nature area with woodland stream and newly updated bridge, picnic area and leisure path.", Acreage = 3.33, AcquiredYear = 1952, DevelopedYear = 1979, Amenities = "Leisure Path: 1,465 Lineal Feet, Nature Area: Woodland Stream, Playground with swings, Picnic Area, 1 Charcoal Grill, 1 ADA Drinking Fountain, 3- 8 Foot Tables, 3 Benches, Bridge" });
            RecreationItems.Add(new RecreationItem { Name = "Heritage Park", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=274"), Location = new GeoCoordinate(40.12699, -82.947249), StreetAddress = "60 N. Cleveland Ave.", IconName = "park", Description = "This 52-acre park is home to the Everal Barn and Homestead which offers visitors a glimpse of Westerville’s past. Through donations and a historic preservation matching grant in 1981, and in 1998, the Department received a NatureWorks Grant through ODNR. After the citizen-driven PROS 2000 income tax increase was passed in 1998, the Everal Barn and Homestead was refurbished into what we see it as today, a truly unique setting where heritage and hospitality meet. Everal Barn and Homestead is a popular place for events, parties, weddings, receptions, family reunions and corporate outings. Also available at Heritage Park is Antrim Shelter, bike/leisure path system, a playground, picnic area, and sports fields.", Acreage = 52.278, AcquiredYear = 1968, DevelopedYear = 2000 });
            RecreationItems.Add(new RecreationItem { Name = "Highlands Park", WebAddress = new Uri("http://www.westerville.org/index.aspx?page=384"), Location = new GeoCoordinate(40.117014, -82.90442), StreetAddress = "245 S. Spring St.", IconName = "park", Description = "Located in the same complex as the new Highlands Park Aquatic Center, Highlands Park offers four baseball diamonds, four soccer/sports fields, two tennis courts, a nature area, wetlands and one-mile bike loop path with ample parking. One open air shelter is located adjacent to the Aquatic Center. Add pool admission on to your next rental for a full day of fun.", });
            RecreationItems.Add(new RecreationItem { Name = "Hoff Woods Park", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=264"), Location = new GeoCoordinate(40.140221, -82.918625), StreetAddress = "556 McCorkle Blvd.", IconName = "baseballfield", Description = "Originally developed in 1996, Hoff Woods Park’s almost 40 acres is home to many baseball tournaments, sporting events, and races. The park includes four lighted baseball diamonds, three lighted basketball courts, two lighted sand-volleyball courts, two lighted tennis courts, a woodland leisure trail, a concession area, picnic area, open-air shelter, pond for fishing, and a newly installed playground. There is ample parking for your next party or event.", Acreage = 39.28, AcquiredYear = 1994, DevelopedYear = 1996 });
            RecreationItems.Add(new RecreationItem { Name = "Huber Village Park", WebAddress = new Uri("http://www.westerville.org/index.aspx?page=386"), Location = new GeoCoordinate(40.103959, -82.909613), StreetAddress = "362 Huber Village Blvd.", IconName = "baseballfield", Description = "This 27 acre park, made possible by funding from PROS 2000, is within walking distance to neighborhoods and schools. Enjoy the eight baseball diamonds, soccer/sports fields, woodland and wetland nature areas, open-air shelter, and playground known as Planet Westerville. The playground has gone through a major upgrade being newly installed in 2000 but keeps its original heritage of the two entrance towers." });
            RecreationItems.Add(new RecreationItem { Name = "Millstone Creek Park", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=261"), Location = new GeoCoordinate(40.14515, -82.902328), StreetAddress = "745 N. Spring St.", IconName = "park", Description = "The newest Westerville Park, Millstone Creek Park and Nature Play Area, was dedicated in the spring of 2010 and features an Inclusive Playground and Nature Play Area. Highlights of the Inclusive Playground include: ramps for wheelchair access; music, exercise, rock, climber, motion play, balance, digging, Neos 360 and skilled play features; canopies for shade; tightrope; slides; swings; and activity panels. The Nature Play Area features plant play, water play, earth play and natural object play. The park also features a shelter house and restroom facility, basketball court, soccer fields and bike paths.", Acreage = 15.27, AcquiredYear = 2007, DevelopedYear = 2010 });
            RecreationItems.Add(new RecreationItem { Name = "Olde Town Park", WebAddress = new Uri("http://www.westerville.org/index.aspx?page=481"), Location = new GeoCoordinate(40.13386, -82.929013), StreetAddress = "108 Old County Line Rd.", IconName = "park", Description = "This neighborhood park is located on over 8 acres in Old Westerville and is convenient to homes and schools. Enjoy the open shelter, bike path, playground and picnic area throughout the year." });
            RecreationItems.Add(new RecreationItem { Name = "Paul Metzger Park", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=387"), Location = new GeoCoordinate(40.129217, -82.960269), StreetAddress = "137 Granby Pl.", IconName = "park", Description = "Named after Paul S. Metzger and built with PROS 2000 funding, Metzger Park offers four soccer fields, four ball diamonds, two basketball courts, two tennis courts, a playground and nature area. Metzger is an all season park, in the winter months you can often find ice skaters at the manmade ice skating rink while in the spring, summer and fall months find visitors picnicking, jogging/walking on the leisure path, playing sports or getting together with friends and family in the open-air shelter." });
            RecreationItems.Add(new RecreationItem { Name = "Spring Grove North", Location = new GeoCoordinate(40.130903, -82.888407), StreetAddress = "1201 E. County Line Rd.", IconName = "park", Description = "This ADA accessible park located off County Line Rd in Westerville is home to a playground, basketball court, picnic area and large fields for playing games or to hold a birthday party or event in the open air shelter. Enjoy a bike ride through the park and stop at the bike hub for some great information about Parks and Recreation." });
            RecreationItems.Add(new RecreationItem { Name = "Towers Park", WebAddress = new Uri("http://www.westerville.org/index.aspx?page=482"), Location = new GeoCoordinate(40.130739, -82.907344), StreetAddress = "161 N. Spring Rd.", IconName = "baseballfield", Description = "This neighborhood park in Westerville is located close to schools and homes. Enjoy a jog down the bike path, play on the playground, plan a family gathering at the open shelter or catch a softball/baseball game at the many sports fields. There is ample parking for all to come and have a great day at the park." });
            RecreationItems.Add(new RecreationItem { Name = "Walnut Ridge Park", WebAddress = new Uri("http://www.westerville.org/index.aspx?page=480"), Location = new GeoCoordinate(40.118634, -82.910954), StreetAddress = "529 E. Walnut Rd.", IconName = "park", Description = "Enjoy a stop at Walnut Ridge Park, with its shelter with picnic area, playground ball diamonds, basketball courts and bike path, this is the perfect park for the kids to enjoy a day out or for families to hold a gathering." });
            RecreationItems.Add(new RecreationItem { Name = "Westerville Community Center", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=246"), Location = new GeoCoordinate(40.135568, -82.945291), StreetAddress = "350 N. Cleveland Ave.", IconName = "running", Description = "The Westerville Community Center is a 96,000 sq ft building opened in November 2001 and is situated on 25 acres of gently rolling green space accented by a 2 acre pond. Convenient from anywhere in the Westerville area, the Community Center is located near steadily growing business developments, I-71 and the major intersection of Polaris Parkway and Cleveland Avenue. The Community Center offers residents and visitors alike easy access to year-round recreational and leisure opportunities including an indoor water-park, fitness room, gymnasium, aerobics room, teen room, climbing wall, indoor playground, meeting rooms and party rooms.", Acreage = 24.892, AcquiredYear = 1997, DevelopedYear = 2001 });
            RecreationItems.Add(new RecreationItem { Name = "Westerville Sports Complex", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=244"), Location = new GeoCoordinate(40.134049, -82.948682), StreetAddress = "325 N. Cleveland Ave.", IconName = "soccerball", Description = "Located directly across from the Westerville Community Center, this park features soccer fields, basketball hoops, playground, open shelter, restrooms and leisure path system. It is also home to the Field of Heroes in May and many sporting events and activities throughout the year.", Acreage = 51, AcquiredYear = 1997, DevelopedYear = 2001 });
            RecreationItems.Add(new RecreationItem { Name = "Astronaut Grove Park", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=277"), Location = new GeoCoordinate(40.125877, -82.941279), StreetAddress = "290 W. Main St.", IconName = "park", Description = "Astronaut Grove Park was dedicated April 30, 1988 and is a monument to all individuals who lost their lives in the pursuit of space exploration. The central feature of the park is a brick memorial plaza and sculpture titled and depicting a series of hands “Reaching for the Stars”. The sculpture was designed by Kenneth S. Foltz. The park also provides a memorial flag, benches for contemplation, picnic tables and access to Alum Creek.", Acreage = 2.09, AcquiredYear = 1935, DevelopedYear = 1987 });
            RecreationItems.Add(new RecreationItem { Name = "Ben Hanby Park", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=259"), Location = new GeoCoordinate(40.126352, -82.929022), StreetAddress = "4 N. Vine St.", IconName = "park", Acreage = 0.14, AcquiredYear = 1920, DevelopedYear = 1979 });
            RecreationItems.Add(new RecreationItem { Name = "Bicentennial Park", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=260"), Location = new GeoCoordinate(40.125091, -82.931467), StreetAddress = "21 S. State St.", IconName = "park", Acreage = 0.15, AcquiredYear = 1930, DevelopedYear = 1976 });
            RecreationItems.Add(new RecreationItem { Name = "Boyer Nature Preserve", Location = new GeoCoordinate(40.122351, -82.91421), StreetAddress = "452 E. Park St.", IconName = "park", Description = "The 11-acre Boyer Nature Preserve is a hidden gem in Westerville, protecting a small stream-fed glacial kettle pond and wetlands. The winding nature paths take visitors through wooded areas, wetlands, and vernal pools. A boardwalk and floating dock extend out and over the pond, providing unique opportunities to visitors seeking a closer look at the diverse communities of aquatic plants and animals.", Acreage = 11 });
            RecreationItems.Add(new RecreationItem { Name = "College Knoll Wetlands", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=248"), Location = new GeoCoordinate(40.130687, -82.913623), StreetAddress = "400 Susan Ave.", IconName = "wetland", Acreage = 13.765, AcquiredYear = 1991, DevelopedYear = 1996 });
            RecreationItems.Add(new RecreationItem { Name = "Community Tennis Complex", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=271"), Location = new GeoCoordinate(40.118439, -82.921388), StreetAddress = "302 S. Otterbein Ave.", IconName = "tennis", Acreage = 1967, AcquiredYear = 1967, DevelopedYear = 1968 });
            RecreationItems.Add(new RecreationItem { Name = "Electric Mini Park", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=258"), Location = new GeoCoordinate(40.114693, -82.927158), StreetAddress = "400 S. State St.", IconName = "park", Acreage = 0.167, DevelopedYear = 1968 });
            RecreationItems.Add(new RecreationItem { Name = "First Responders Park", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=256"), Location = new GeoCoordinate(40.125339, -82.944538), StreetAddress = "374 W. Main St.", IconName = "park", Description = "First Responders Park located at 374 W. Main Street will include an educational and cultural component for the public in the form of the display of the World Trade Center Steel, interpretive panel documenting historical events and the memorial wall recognizing all First Responders in a park-like setting. Landscaped beds will provide back drop for the interpretive panel. The raised plaza is retained by a section of the memorial wall that will be viewed from the adjacent sidewalk. The City will sponsor, develop and maintain the project as an outdoor facility open to the public free 365 days of the year.", Acreage = 0.276, AcquiredYear = 1920, DevelopedYear = 2010 });
            RecreationItems.Add(new RecreationItem { Name = "Heritage Wetlands", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=248"), Location = new GeoCoordinate(40.133284, -82.913341), StreetAddress = "374 W. Main St.", IconName = "wetland", Acreage = 5.5, AcquiredYear = 1991, DevelopedYear = 1996 });
            RecreationItems.Add(new RecreationItem { Name = "Highlands Park Aquatic Center", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=267"), Location = new GeoCoordinate(40.116325, -82.904667), StreetAddress = "245 S. Spring St.", IconName = "swim", Acreage = 40.94, AcquiredYear = 1969, DevelopedYear = 1973 });
            RecreationItems.Add(new RecreationItem { Name = "Kiwanis Picnic Park", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=257"), Location = new GeoCoordinate(40.1200436, -82.9216237), StreetAddress = "220 S. Otterbein Ave.", IconName = "park", Acreage = 0.78, AcquiredYear = 1957, DevelopedYear = 1980 });
            RecreationItems.Add(new RecreationItem { Name = "Mariners Cove Wetland", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=248"), Location = new GeoCoordinate(40.142238, -82.893514), StreetAddress = "1007 Wake Dr.", IconName = "wetland", Acreage = 5.956, AcquiredYear = 2001, DevelopedYear = 2001 });
            RecreationItems.Add(new RecreationItem { Name = "Otterbein Lake", Location = new GeoCoordinate(40.122772, -82.940608), StreetAddress = "60 Collegeview Rd.", IconName = "wetland", Description = "The City of Westerville bought Otterbein Lake from Otterbein University in the 1990s. Originally created when dirt was removed for construction projects, the 10-acre lake was a well-kept secret until a recently completed stretch of the Alum Creek Bikeway began taking people by it. A committee was formed to develop Otterbein Lake as an environmental, educational, scenic, and recreational oasis that is accessible to all. The lake is bordered by West Main Street, Alum Creek and an office building at 60 Collegeview Road. The bike path along two sides of the lake is part of the Westerville Loop system that connects the Ohio to Erie Trail." });
            RecreationItems.Add(new RecreationItem { Name = "Uptown Rotary Park", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=255"), Location = new GeoCoordinate(40.127355, -82.932105), StreetAddress = "54 N. State St.", IconName = "park", Acreage = 0.035, AcquiredYear = 1969, DevelopedYear = 1991 });
        }

        // Code to execute when the application is activated (brought to foreground)
        // This code will not execute when the application is first launched
        private void Application_Activated(object sender, ActivatedEventArgs e)
        {
        }

        // Code to execute when the application is deactivated (sent to background)
        // This code will not execute when the application is closing
        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {
        }

        // Code to execute when the application is closing (eg, user hit Back)
        // This code will not execute when the application is deactivated
        private void Application_Closing(object sender, ClosingEventArgs e)
        {
        }

        // Code to execute if a navigation fails
        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                // A navigation has failed; break into the debugger
                Debugger.Break();
            }
        }

        // Code to execute on Unhandled Exceptions
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                Debugger.Break();
            }
        }

        #region Phone application initialization

        // Avoid double-initialization
        private bool phoneApplicationInitialized = false;

        // Do not add any additional code to this method
        private void InitializePhoneApplication()
        {
            if (phoneApplicationInitialized)
                return;

            // Create the frame but don't set it as RootVisual yet; this allows the splash
            // screen to remain active until the application is ready to render.
            RootFrame = new PhoneApplicationFrame();
            RootFrame.Navigated += CompleteInitializePhoneApplication;

            // Handle navigation failures
            RootFrame.NavigationFailed += RootFrame_NavigationFailed;

            // Handle reset requests for clearing the backstack
            RootFrame.Navigated += CheckForResetNavigation;

            // Ensure we don't initialize again
            phoneApplicationInitialized = true;
        }

        // Do not add any additional code to this method
        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
            // Set the root visual to allow the application to render
            if (RootVisual != RootFrame)
                RootVisual = RootFrame;

            // Remove this handler since it is no longer needed
            RootFrame.Navigated -= CompleteInitializePhoneApplication;
        }

        private void CheckForResetNavigation(object sender, NavigationEventArgs e)
        {
            // If the app has received a 'reset' navigation, then we need to check
            // on the next navigation to see if the page stack should be reset
            if (e.NavigationMode == NavigationMode.Reset)
                RootFrame.Navigated += ClearBackStackAfterReset;
        }

        private void ClearBackStackAfterReset(object sender, NavigationEventArgs e)
        {
            // Unregister the event so it doesn't get called again
            RootFrame.Navigated -= ClearBackStackAfterReset;

            // Only clear the stack for 'new' (forward) and 'refresh' navigations
            if (e.NavigationMode != NavigationMode.New && e.NavigationMode != NavigationMode.Refresh)
                return;

            // For UI consistency, clear the entire page stack
            while (RootFrame.RemoveBackEntry() != null)
            {
                ; // do nothing
            }
        }

        #endregion

        // Initialize the app's font and flow direction as defined in its localized resource strings.
        //
        // To ensure that the font of your application is aligned with its supported languages and that the
        // FlowDirection for each of those languages follows its traditional direction, ResourceLanguage
        // and ResourceFlowDirection should be initialized in each resx file to match these values with that
        // file's culture. For example:
        //
        // AppResources.es-ES.resx
        //    ResourceLanguage's value should be "es-ES"
        //    ResourceFlowDirection's value should be "LeftToRight"
        //
        // AppResources.ar-SA.resx
        //     ResourceLanguage's value should be "ar-SA"
        //     ResourceFlowDirection's value should be "RightToLeft"
        //
        // For more info on localizing Windows Phone apps see http://go.microsoft.com/fwlink/?LinkId=262072.
        //
        private void InitializeLanguage()
        {
            try
            {
                // Set the font to match the display language defined by the
                // ResourceLanguage resource string for each supported language.
                //
                // Fall back to the font of the neutral language if the Display
                // language of the phone is not supported.
                //
                // If a compiler error is hit then ResourceLanguage is missing from
                // the resource file.
                RootFrame.Language = XmlLanguage.GetLanguage(AppResources.ResourceLanguage);

                // Set the FlowDirection of all elements under the root frame based
                // on the ResourceFlowDirection resource string for each
                // supported language.
                //
                // If a compiler error is hit then ResourceFlowDirection is missing from
                // the resource file.
                FlowDirection flow = (FlowDirection)Enum.Parse(typeof(FlowDirection), AppResources.ResourceFlowDirection);
                RootFrame.FlowDirection = flow;
            }
            catch
            {
                // If an exception is caught here it is most likely due to either
                // ResourceLangauge not being correctly set to a supported language
                // code or ResourceFlowDirection is set to a value other than LeftToRight
                // or RightToLeft.

                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }

                throw;
            }
        }
    }
}