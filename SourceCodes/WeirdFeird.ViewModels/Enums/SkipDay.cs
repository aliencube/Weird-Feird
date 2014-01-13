namespace Aliencube.WeirdFeird.ViewModels.Enums
{
    /// <summary>
    /// This specifies a hint for aggregators telling them which days they can skip. This element contains up to seven days sub-elements whose value is Monday, Tuesday, Wednesday, Thursday, Friday, Saturday or Sunday. Aggregators may not read the channel during days listed in the <c>SkipDays</c> instance.
    /// </summary>
    public enum SkipDay
    {
        Monday = 0,
        Tuesday = 1,
        Wednesday = 2,
        Thursday = 3,
        Friday = 4,
        Saturday = 5,
        Sunday = 6,
    }
}