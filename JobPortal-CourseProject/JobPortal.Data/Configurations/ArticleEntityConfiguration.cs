namespace JobPortal.Data.Configurations
{
    using Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ArticleEntityConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasData(GenerateArticles());
        }
        
        private Article[] GenerateArticles()
        {
            ICollection<Article> articles = new HashSet<Article>();

            Article article;

            article = new Article()
            {
                Title = "Making a Career Change. Career Advice for a Post-Pandemic Workplace",
                Summary = "There’s nothing quite like a pandemic for prompting reflections on the truly big questions like “What do I want to do with my life?”.",
                Text = "Lockdown has given us extra thinking time away from the hustle and bustle of the commute, the distractions of the open plan office and our busy personal lives.\r\n" +
                       "It’s therefore unsurprising that according to a recent survey by Aviva, 60% of workers are planning a career change in what is being called “The Great Resignation”.  Sometimes it’s only when you step off the treadmill and see where you are, that you realise you want to be somewhere different.\r\n" +
                       "Corinne Mills, Managing Director of Personal Career Management a leading career coaching company, shares her insights on managing your career in a post-pandemic world, where the workplace and our relationship with it, is rapidly evolving.\r\n" +
                       "Shape how you work\r\n" +
                       "The pandemic has opened the possibilities of working in different ways.  Remote working has reduced many of the tensions associated with office life, such as a stressful commute, an overbearing boss or the interruptions of a shared communal space.  It’s also brought a new authenticity as we tend to be much more comfortable within our domestic setting than the performance playground of the office.  No wonder that according to the EY 2021 Work Reimagined Survey,.4 out of 5 workers say that they would find another job rather than go back to work in the office full-time.\r\n" +
                       "Yet while there are undoubted benefits of flexible working, there are career risks in this too. It would be very easy for your professional world to become small and transactional.  This leaves you in danger of being overlooked and therefore vulnerable.  It’s much harder to build wider and substantive relationships with people when there’s few opportunities to mingle but it is going to become even more important that you do.\r\n" +
                       "Developing your visibility post-pandemic doesn’t only mean updating your LinkedIn.  You’ll need to find opportunities to grow your job and get in front of key people.  Talk to your boss about how in addition to working on your key tasks, you might also develop particular areas you are interested in, especially if they give you exposure to new people and other parts of the business. \r\n" +
                       "Ask for a mentor, offer to become a brand ambassador or internal champion for internal well-being or charity initiatives.  Volunteer for projects that are cross-organisational, or suggest that you spend time talking to customers, suppliers, or stakeholders, to gather research or investigate a long-standing issue.\r\n" +
                       "Externally you also need to be networking.  This might be through a relevant professional group or association.  There are so many available and most of them are running virtual events. If and when you are in the office, use it to have face to face discussions with as many people as you can, including scheduling after work meet-ups.\r\n" +
                       "We may have sensibly retreated to our cave during the pandemic, but if we stay there, we lose the richness and energy of interacting with different people who we can learn from and who may be able to help us with our career.",
                AuthorId = Guid.Parse("e30fae8e-5a56-4112-9250-aff3affb75a4")
            };
            articles.Add(article);

            article = new Article()
            {
                Title = "10 Essential Career-Boosting and Career Survival Tips for Managing your Career during a Pandemic",
                Summary = "So at a time of huge societal disruption, how do you shift your career to a place that better reflects your new priorities while still protecting your livelihood? Here’s our essential tips.",
                Text = "It’s amazing how quickly most of us have adapted to home working.  We’ve got past the giggly phase of seeing ourselves on video calls and waving goodbye like a toddler.  We’ve also become far more relaxed about interruptions from children, cats and snoring dogs as we ditch the smart office attire, cut our own fringes and dispense with shoes.  For many people this has been a positive change, a liberation from the commute and office politics.\r\n" +
                       "It’s also given us time to think about our life and career priorities.  While people are understandably keen to hang onto their jobs given the widespread redundancies and difficult job market, many people are also realising that the career path they’ve been treading is no longer as attractive or even as viable as it had been pre-pandemic.\r\n" +
                       "So at a time of huge societal disruption, how do you shift your career to a place that better reflects your new priorities while still protecting your livelihood?  Here’s our essential tips.\r\n" +
                       "Internal PR\r\n" +
                       "As a career coach at Personal Career Management, I talk every day with individuals who thought their job was safe until the moment they were told they would be leaving.  Positively managing your reputation within your organisation needs to be an ongoing activity and this becomes especially important if you are working remotely and are less visible.  Share your successes with your boss and other key decision-makers rather than just the problems.  Reminding them what an asset you are will help position you for career development opportunities or encourage them to redeploy you, if there are redundancies.\r\n" +
                       "Think radical\r\n" +
                       "Virtual events, healthcare consultations via skype and restaurant food home deliveries are just a few examples of organisations thinking creatively about how to continue their operations and identify new revenue streams.   Share any ideas you have that could help your company make sense of the new landscape and suggest you take a lead on this to scope out its potential.  It’s an interesting career building development opportunity for you, increases your visibility and helps the organisation too.\r\n" +
                       "Ramp up your learning\r\n" +
                       "Employees have to be agile to contend with the fast-changing landscape.  If you have a growth mind-set and a demonstrated willingness to learn then you will be more employable and more likely to be retained.  It’s smart to make learning a regular habit.  Seek out new learning opportunities at work and externally as there are so many accessible learning opportunities right now, whether it is free webinars, online study courses or even a part-time University degree or MBA.\r\n" +
                       "The career positives of a crisis\r\n" +
                       "For many of us, the pandemic has brought some of the most difficult professional challenges of our career.  Maybe you’ve had to re-jig operations, reassure anxious customers and staff, handle  furloughing or staff redundancies.  Perhaps you volunteered for community work, helping people in your street or a local charity.  You may have done all of these things simply because it was your job or you wanted to be useful.  However, what they reveal is your resilience and resourcefulness, your ability to get things done even in the midst of a crisis.  Future employers will definitely want to hear about these mettle-testing career achievements so speak up about them.\r\n" +
                       "Don’t worry about a career derail\r\n" +
                       "If you find yourself needing to take on a role which isn’t necessarily your first choice, then don’t worry about whether it will affect your future prospects.  Ordinarily employers are suspicious about career change or detours, but in these unusual circumstances, most of them fully appreciate that individuals need to be pragmatic and versatile in order to pay their bills.  You will still need to show motivation and perform well in whatever role you undertake, but this doesn’t stop you from continuing to look for your more ideal role.\r\n" +
                       "Go where the demand is\r\n" +
                       "Some sectors such as technology, supermarkets and healthcare  are in growth mode while others such as the High street retail, travel, tourism and live arts are sadly struggling right now.   Read the business news and reports by recruitment agencies to find out which sectors are recruiting.   Explore the companies who operate in these spaces and the roles they have where you could use your transferable skills.  Use LinkedIn to identify individuals you know who work in these areas and who could give you advice and suggest a way in for you.\r\n" +
                       "Side hustle\r\n" +
                       "If you’re no longer commuting, perhaps you have additional bandwidth to consider other supplementary ways to boost your income.  Perhaps you could offer online tutoring in your area of expertise, renovate a property, create an online artisan shop, or offer graphic design services or mentoring.  Portfolio working is going to become increasingly common as individuals working from home use their new flexibility to balance different interests and income streams.\r\n" +
                       "Cut yourself some slack\r\n" +
                       "The pandemic has reminded us that life is precious and while work is necessary and can be life-affirming, it shouldn’t be all-consuming.   Despite this, burn-out has become another symptom of this pandemic with many individuals feeling increasingly exhausted by the professional and personal challenges they face.  Build activities into your week which are enjoyable and completely removed from work.  Find your off-switch and recharge.\r\n" +
                       "The key is other people\r\n" +
                       "Our restricted work and social bubbles may keep us safer but they’ve also made it more difficult to use the most effective career management strategy there is, namely our relationships with other people.  Engaging with others increases our visibility, helps us positively influence perceptions and builds our reputation as someone who would be good to work with or who can be recommended to others. Advice and feedback helps confirm we are on the right track and where we need to develop.  We hear from others about opportunities that we otherwise would have missed.\r\n" +
                       "It’s important that you create opportunities for dialogue with key influencers at work, get in touch with your connections and join online networking groups to extend your circle.  Working with a career coach as a guide and sounding board can be enormously helpful with tricky career challenges  and building confidence.  Other people will help you but it’s up to you to reach out to them.",
                AuthorId = Guid.Parse("e30fae8e-5a56-4112-9250-aff3affb75a4")
            };
            articles.Add(article);

            return articles.ToArray();
        }
    }
}