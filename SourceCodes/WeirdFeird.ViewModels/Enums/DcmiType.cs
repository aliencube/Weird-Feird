namespace Aliencube.WeirdFeird.ViewModels.Enums
{
    /// <summary>
    /// This specifies the nature or genre of the resource.
    /// </summary>
    /// <remarks>
    /// Recommended best practice is to use a controlled vocabulary such as the DCMI Type Vocabulary [DCMITYPE](http://dublincore.org/documents/dcmi-type-vocabulary/). To describe the file format, physical medium, or dimensions of the resource, use the Format element.
    /// </remarks>
    public enum DcmiType
    {
        Collection = 0,
        Dataset = 1,
        Event = 2,
        Image = 3,
        InteractiveResource = 4,
        MovingImage = 5,
        PhysicalObject = 6,
        Service = 7,
        Software = 8,
        Sound = 9,
        StillImage = 10,
        Text = 11,
    }
}