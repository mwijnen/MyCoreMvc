using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace MyCoreMvc.Models
{
    public static class SeedDatabase
    {
        public static void EnsurePopulated(ApplicationDbContext context)
        {
            if (!context.Posts.Any())
            {
                context.Posts.AddRange(
                    new Post { Created = DateTime.Now, Updated = DateTime.Now, Title = "SeedTitle", SubTitle = "SeedSubTitle", CreatedByUserId = "SeedUserId", Body = LongBody() },
                    new Post { Created = DateTime.Now, Updated = DateTime.Now, Title = "SeedTitle", SubTitle = "SeedSubTitle", CreatedByUserId = "SeedUserId" });
                context.SaveChanges();
            }
        }

        private static string LongBody()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 100; i++)
            {
                sb.Append(loremIpsum);
            }
            return sb.ToString();
        }

        private static string loremIpsum = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean diam mi, consectetur vitae odio eu, commodo facilisis turpis. Cras efficitur lacus tellus, sit amet gravida metus pretium at. Etiam sollicitudin iaculis elit sed varius. Maecenas vitae ultricies diam. Donec id blandit lacus. Duis pretium velit sit amet libero dignissim, a tincidunt massa feugiat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla facilisi. Quisque vel neque nisi. Proin laoreet est risus. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Maecenas quis euismod libero. Ut pretium purus nec urna bibendum, eu egestas turpis eleifend. Nullam a porttitor massa. Quisque maximus dolor vel metus tempor condimentum. Phasellus venenatis nisl pretium, viverra metus eu, faucibus ante. Proin ultrices placerat magna ut malesuada. Donec neque sem, convallis congue arcu a, hendrerit accumsan lectus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam pharetra turpis sit amet neque porta faucibus. Mauris aliquam porttitor ante ac interdum. Duis a finibus metus. Integer in diam vel purus imperdiet cursus. Nulla orci arcu, vehicula quis porta eget, condimentum a enim. Suspendisse posuere massa ac felis blandit ultricies id vitae orci. Donec pharetra, tortor vel sodales congue, ligula justo faucibus lacus, non mattis mauris arcu in purus. Pellentesque rutrum, lorem vitae sodales eleifend, nulla elit convallis nunc, vel sagittis augue tortor ac felis. Proin viverra turpis ac dignissim egestas. Donec scelerisque consequat purus, eget pellentesque arcu egestas bibendum. Duis ullamcorper porttitor dolor nec ultrices. Phasellus laoreet, metus at sodales aliquet, augue metus euismod nibh, eget tempus ex lorem sit amet orci. Proin blandit metus in tortor vehicula volutpat. Mauris ut rutrum enim, eget varius tortor. Ut semper semper iaculis. Aliquam dui lorem, bibendum non tempus quis, volutpat congue justo. Duis sit amet sapien placerat, maximus mi vitae, consequat magna. Nunc lacinia lorem vitae erat viverra posuere. Ut non lectus nec nisl venenatis scelerisque ut vitae mauris. Phasellus vitae dignissim odio, nec ornare odio. Etiam felis est, ornare et molestie et, iaculis ut libero. Quisque ut tortor commodo, malesuada lorem in, faucibus massa. Morbi quis gravida tellus, vitae aliquam magna. Cras nisi elit, porttitor eget dapibus sit amet, rhoncus vel purus. Cras tempus nisi non convallis commodo. Pellentesque vehicula in sapien vitae tincidunt. Nulla suscipit augue quis vestibulum iaculis. Morbi eget tellus neque. In ullamcorper, dui auctor congue varius, purus velit bibendum lacus, in finibus sem nulla vel justo. Pellentesque efficitur molestie dolor, suscipit vulputate odio mollis sit amet. Nunc id condimentum dui. Nullam eu tempus nisi. Suspendisse tincidunt risus ac sapien gravida, ut efficitur ante malesuada. Integer vitae enim posuere, aliquet libero vitae, facilisis sem. Donec lacinia quis est nec ullamcorper. Nulla in pharetra arcu. Nulla facilisi. In blandit imperdiet consectetur. Quisque turpis ex, accumsan at convallis vitae, egestas in justo. Ut ac dictum dolor. Curabitur accumsan ex eu eros sodales pulvinar. Duis et tincidunt felis. Nunc scelerisque felis at ante luctus mattis. Morbi nunc velit, rutrum fringilla arcu non, tincidunt laoreet velit. Nullam ac volutpat mi. Fusce eros nisi, tristique quis enim id, dignissim tincidunt nisi. Quisque nec nunc ac ex dapibus suscipit. Nam quis sem lacus.";
    }
}

