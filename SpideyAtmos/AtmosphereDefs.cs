using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherTuner
{
    public class AtmosphereDefs
    {
        public enum t
        {
            Float,
            Int
        }

        // Atmosphere definitions
        //------------------------------------------------------------------------------------------
        // Hello there! These are the atmosphere definitions. I've divided them into two sections.
        // One for numerical values, and another for hashes (so it's easier to work with them).
        //
        // Offsets are relative to the beginning of the atmosphere content section (only section
        // in MSM2 atmospheres).
        //
        // You can update any definition here and it'll show up in the list. Most definitions are
        // grouped together in the .atmosphere file, so we use "settingsRanges" to group settings
        // between a minimum and maximum offset.
        //------------------------------------------------------------------------------------------

        public static List<(string Name, int Address, t value, string Description)> Values = new() {
            // Key Light settings
            //--------------------------------------------------------------------------------------
            ("Sky Box Sun Threshold", 240, t.Float, "Values greater than this in the sky box are clamped during lighting capture"),
            ("Sky Box Azimuth rotation", 244, t.Float, "A rotation value in degrees to rotate the image in the sky box cube map (-180 to 180)"),
            ("Key Light Material Scale", 192, t.Float, "The world-space scale in meters for the keylight material"),
            ("Key Light Color RGB Red", 104, t.Float, "Sun / Moon color"),
            ("Key Light Color RGB Green", 108, t.Float, ""),
            ("Key Light Color RGB Blue", 112, t.Float, ""),
            ("Key Light Intensity", 116, t.Float, ""),
            ("Key Light Azimuth", 120, t.Float, "The azimuthal direction of the keylight in degrees (0 to 360)"),
            ("Key Light Elevation", 124, t.Float, "The elevation direction of the keylight in degrees (0 = horizon, 90 = straight down)"),
            ("Time Of Day", 160, t.Float, "Normalized time of day. 0=blackout, 0.25=Overcast, 0.5=Day, 0.75=Sunset, 1=Night"),
            ("Sun Diameter", 164, t.Float, "Apparent angular diameter of solar disk in degrees (it's 0.5 in real life)"),
            ("Sun Disk Offset Azimuth", 128, t.Float, "An azimuthal offset from the keylight direction for where the sun will be drawn in the sky (-180 to 180)"),
            ("Sun Disk Offset Elevation", 132, t.Float, "An elevation offset from the keylight direction for where the sun will be drawn in the sky (-90 to 90)"),
            ("Caster Range Upper", 152, t.Float, "The Y height in meters above which nothing needs to cast or receive shadows"),
            ("Caster Range Lower", 156, t.Float, "The Y height in meters below which nothing needs to cast or receive shadows"),
            ("Shadow Softness", 196, t.Float, "Sets a minimum penumbra size for key light shadows. Penumbra may be larger if the CSM doesn't have enough resolution."),
            ("CSM Base Lod Range", 136, t.Float, "The distance in meters that the base (non-cached) csm lods extend. If there are no cached far lods, this is where the shadow will fade out."),
            ("CSM Base Lod Count", 140, t.Int, "The number of base (non-cached) csm lods"),
            ("CSM Far Lod Count", 144, t.Int, "The number of cached csm lods that exist beyond the base lods. These lods contain only static casters and update only when necessary. Each cached lod will be 2.5x bigger than the previous lod. The first lod is sized relative to the Base Lod Rangee."),
            ("CSM Perf Mode Optimization", 148, t.Int, "If enabled, in Performance modes the base lod range and Base lod count will be reduced slightly to improve performance."),
            ("VFX Light Multiplier", 236, t.Float, "Multiplier applied to lights spawned by VFX lights"),
            ("Proxy Light Distance Scale", 248, t.Float, "Scales the distance at which standard lights change to proxy lights"),
            ("Light grid bounds min X", 256, t.Float, ""),
            ("Light grid bounds min Y", 260, t.Float, ""),
            ("Light grid bounds min Z", 264, t.Float, ""),
            ("Light grid bound max X", 268, t.Float, ""),
            ("Light grid bound max Y", 272, t.Float, ""),
            ("Light grid bound max Z", 276, t.Float, ""),
            //--------------------------------------------------------------------------------------

            // Tone map
            //--------------------------------------------------------------------------------------
            ("Enable Tone Mapping", 1312, t.Int, ""),
            ("Adaptation Anchor (EVs)", 1316, t.Float, ""),
            ("Adaptation Range (EVs)", 1320, t.Float, ""),
            ("AutoAdjustTime", 1324, t.Float, ""),
            ("Constrast Scale", 1328, t.Float, "Contols the variation of each local area from the target midpoint. Lower values result in local areas being pulled closer to the target midpoint. A value of 1.0 disables spatial tone mapping adjustments."),
            ("Midpoint Adjustment", 1332, t.Float, "Offsets the target midpoint used by local tone mapping from the global adapted luminance midpoint."),
            ("Detail Strength", 1336, t.Float, "Controls the amount of per pixel luminance variation within a local tone map area. Values above 1.0 give the image more pop."),
            ("Highlight Darkening", 1340, t.Float, "Further darkens local areas that are above the target midpoint. A value of 0 means areas above the target midpoint will be darkened as much as"),
            ("Shadow brightening", 1344, t.Float, "Limits the degree to which local tone mapping can brighten pixels. A value of 0 prevents any increase in luminance. A value of 1 remove the brightening limit."),
            //--------------------------------------------------------------------------------------

            // Bloom
            //--------------------------------------------------------------------------------------
            ("Bloom intensity", 1352, t.Float, "The fraction of the image's light energy that is added back on as bloom"),
            ("Bloom threshold", 1356, t.Float, "The number of times brighter than middle gray a pixel has to be before it starts blooming"),
            ("Narrowest Strength", 1360, t.Float, "The strength of the narrowest gaussian band"),
            ("Narrow Strength", 1364, t.Float, "The strength of the second narrowest gaussian band"),
            ("Middle Strength", 1368, t.Float, "The strength of the middle gaussian band"),
            ("Wide Strength", 1372, t.Float, "The strength of the second widest gaussian band"),
            ("Widest Strength", 1376, t.Float, "The strength of the widest gaussian band"),
            ("Dirtiness", 1380, t.Float, ""),
            ("LF Lum Min", 1408, t.Float, "LF bloom starts when a pixel is this many times brighter than the average luminance"),
            ("LF Lum Max", 1412, t.Float, "LF bloom maxes out when a pixel is this many times brighter than the average luminance"),
            ("LF Lum Intensity", 1416, t.Float, "The overall intensity of the bloom that feeds into the lens flare system"),
            ("LF Ghosts", 1420, t.Float, ""),
            ("LF FallOff", 1424, t.Float, ""),
            ("LF Intensity", 1428, t.Float, ""),
            ("LF Distortion", 1432, t.Float, ""),
            ("LF Halo Radius", 1436, t.Float, ""),
            ("LF Halo Intensity", 1440, t.Float, ""),
            ("LF Ghost Dispersal", 1444, t.Float, ""),
            ("AMFL Intensity", 1448, t.Float, "The overall intensity of the flare.  This scales the radiance before it is blurred and stretched to produce the flare.  If this value is set to zero, the system is turned off."),
            ("AMFL Value Threshold", 1452, t.Float, "This is the pre-tonemap minimum threshold for Value in HSV space for a pixel to get added to the flare.  This is used to ensure that the colors have some high value before being considered for the flare."),
            ("AMFL Saturation Threshold", 1456, t.Float, "This is the pre-tonemap minimum threshold for Saturation in HSV space for a pixel to get added to the flare.  This is used to ensure that colors are preferred for flares over white hotspots."),
            ("AMFL Size", 1460, t.Float, "This is the normalized size of the kernal [0..1] which will change the size of the flare"),
            //--------------------------------------------------------------------------------------

            // Color Correction
            //--------------------------------------------------------------------------------------
            ("Enable Color Correction", 1588, t.Int, ""),
            ("White Balance Temp", 1464, t.Float, "Adjusts what color temperature maps to paper white relative to the default 6500K. Negative numbers shift the image cooler, positive numbers shift it warmer."),
            ("White Balance Tint", 1468, t.Float, "Fine tune the white balance along the green/magenta axis perpendicular to the blue/orange axis of the color temperature. Negative numbers shift the image greener, positive numbers shift it pinker."),
            ("Pre Exposure", 1472, t.Float, "An adjustment to the overall brightness (in stops) that is applied prior to all other color grading operations."),
            ("Post Exposure", 1476, t.Float, "An adjustment to the overall brightness (in stops) that is applied after all other color grading operations, just prior to tone-mapping. This is effectively the same as the tone-mapping Adaptation Bias property."),
            ("Hue Shift", 1480, t.Float, "Shifts the hue across the entire image by the specified number of degrees (-180 to 180)."),
            ("Contrast", 1484, t.Float, "Adjusts the contrast across the entire image. Positive values increase the contrast. Negative values decrease the contrast."),
            ("Saturation", 1488, t.Float, "Adjusts the saturation across the entire image. Positive values increase the saturation. Negative values decrease the saturation."),
            ("Color Boost", 1492, t.Float, "Similar to the saturation control, but applies the saturation effect more strongly to desaturated colors and less strongly to colors that are already saturated."),
            ("Lift RGB Red", 1496, t.Float, "An adjustment that primarily affects the dark tones of the image."),
            ("Lift RGB Green", 1500, t.Float, ""),
            ("Lift RGB Blue", 1504, t.Float, ""),
            ("Gamma RGB Red", 1508, t.Float, "An adjustment that primarily affects the mid-tones of the image."),
            ("Gamma RGB Green", 1512, t.Float, ""),
            ("Gamma RGB Blue", 1516, t.Float, ""),
            ("Gain RGB Red", 1520, t.Float, "An adjustment that primarily affects the bright tones of the image."),
            ("Gain RGB Green", 1524, t.Float, ""),
            ("Gain RGB Blue", 1528, t.Float, ""),
            ("Shadows RGB Red", 1532, t.Float, "A log-space adjustment applied to the dark tones of the image."),
            ("Shadows RGB Green", 1536, t.Float, ""),
            ("Shadows RGB Blue", 1540, t.Float, ""),
            ("Midtones RGB Red", 1544, t.Float, "A log-space adjustment applied to the mid-tones of the image."),
            ("Midtones RGB Green", 1548, t.Float, ""),
            ("Midtones RGB Blue", 1552, t.Float, ""),
            ("Highlights RGB Red", 1556, t.Float, "A log-space adjustment applied to the highlights of the image."),
            ("Highlights RGB Green", 1560, t.Float, ""),
            ("Highlights RGB Blue", 1564, t.Float, ""),
            ("Shadows Sat", 1568, t.Float, "Adjusts the saturation in the dark tones of the image. Positive values increase the saturation. Negative values decrease the saturation."),
            ("Midtone Sat", 1572, t.Float, "Adjusts the saturation in the mid-tones of the image. Positive values increase the saturation. Negative values decrease the saturation."),
            ("Highlights Sat", 1576, t.Float, "Adjusts the saturation in the highlights of the image. Positive values increase the saturation. Negative values decrease the saturation."),
            ("Shadows limit", 1580, t.Float, ""),
            ("Highlights limit", 1584, t.Float, ""),
            //--------------------------------------------------------------------------------------

            // Vignette
            //--------------------------------------------------------------------------------------
            ("Vignette Intensity", 1616, t.Float, "The intensity of the darkening effect"),
            ("Vignette Center Clear", 1620, t.Float, "The radius of the undarkened circle in the center of the screen (0.5 means half the distance from the center to the farther screen edge)"),
            //--------------------------------------------------------------------------------------

            // Chromatic aberration
            //--------------------------------------------------------------------------------------
            ("Chromatic Inner Radius", 1624, t.Float, "The radius of the circle in the center of the screen where there is no effect (0.5 means half the distance from the center to farther screen edge)"),
            ("Chromatic Outer Radius", 1628, t.Float, "The radius of the circle where the effect reaches full strength (1.0 means the distance from the center to the farther screen edge)"),
            ("Displacement in Pixels", 1632, t.Float, "The distance in pixels (relative to a 1080P screen) that the red channel is offset from the blue channel when the effect is at full strength"),
            ("Blur in pixels", 1636, t.Float, "The size of the blur kernel when the effect is at full strength"),
            //--------------------------------------------------------------------------------------

            // Fog
            //--------------------------------------------------------------------------------------
            ("Near radius", 1732, t.Float, ""),
            ("Bottom Height", 1736, t.Float, ""),
            ("Second Height", 1740, t.Float, ""),
            ("Third Height", 1744, t.Float, ""),
            ("Fourth Height", 1748, t.Float, ""),
            ("Top Height", 1752, t.Float, ""),
            ("1st Height Opacity", 1756, t.Float, ""),
            ("2nd Height Opacity", 1760, t.Float, ""),
            ("3rd Height Opacity", 1764, t.Float, ""),
            ("4th Height Opacity", 1768, t.Float, ""),
            ("5th Height Opacity", 1772, t.Float, ""),
            ("S-Curve Strength", 1776, t.Float, ""),
            ("S-Curve Center", 1780, t.Float, ""),
            ("Color Map Depth Range", 1888, t.Float, ""),
            ("Color Map Depth Scale", 1892, t.Float, ""),
            //--------------------------------------------------------------------------------------

            //--------------------------------------------------------------------------------------
            ("Motion Blur Exposure Duration", 1952, t.Float, ""),
            //--------------------------------------------------------------------------------------

            //--------------------------------------------------------------------------------------
            ("Near Focus Distance", 1960, t.Float, ""),
            ("Near Aperture Scale", 1964, t.Float, ""),
            ("Far Focus Distance", 1968, t.Float, ""),
            ("Far Aperture Scale", 1972, t.Float, ""),
            //--------------------------------------------------------------------------------------

            //--------------------------------------------------------------------------------------
            ("Size", 1976, t.Float, ""),
            ("Strength", 1980, t.Float, ""),
            ("Size at 4K", 1984, t.Float, "Size at 4k resolution. If 0, it will automatically derive from Size."),
            ("Strength at 4K", 1988, t.Float, "Strength at 4k resolution. If 0, it will automatically derive from Strength."),
            //--------------------------------------------------------------------------------------

            //--------------------------------------------------------------------------------------
            ("Rayleigh Density", 2016, t.Float, ""),
            ("MieDensity", 2020, t.Float, ""),
            ("MieAlbedo RGB Red", 2024, t.Float, ""),
            ("MieAlbedo RGB Green", 2028, t.Float, ""),
            ("MieAlbedo RGB Blue", 2032, t.Float, ""),
            //--------------------------------------------------------------------------------------

            //--------------------------------------------------------------------------------------
            ("Range", 2040, t.Float, ""),
            ("Weight", 2044, t.Float, ""),
            ("Cone angle", 2048, t.Float, ""),
            ("Sort distance", 2052, t.Float, "The distance (in meters) at which the light shafts effect is inserted into the alpha sort layer. Generally 0 works best to avoid popping with vfx, but in cinematic situations it can look better to sort light shafts farther away than far DoF"),
            ("Light Shaft Color Red", 2056, t.Float, ""),
            ("Light Shaft Color Green", 2060, t.Float, ""),
            ("Light Shaft Color Blue", 2064, t.Float, ""),
            ("Cloud Shadow Bias", 2068, t.Float, "Adds a bias to volumetric cloud shadow map transparency. A value of 0 will have no effect. Positive values will reduce shadow map occlusion from volumetric clouds. Negative values will increase the amount of occlusion."),
            //--------------------------------------------------------------------------------------

            //--------------------------------------------------------------------------------------
            ("Clip near", 2072, t.Float, "Set to 0 to disable"),
            ("Clip Far", 2076, t.Float, "Set to 0 to disable"),
            //--------------------------------------------------------------------------------------

            //--------------------------------------------------------------------------------------
            ("Custom 1", 1640, t.Float, ""),
            ("Custom 2", 1644, t.Float, ""),
            ("Custom 3", 1648, t.Float, ""),
            ("Custom 4", 1652, t.Float, ""),
            //--------------------------------------------------------------------------------------

            //--------------------------------------------------------------------------------------
            ("AO Occlusion Strength", 1656, t.Float, "The strength of the SSAO effect in the foreground"),
            ("AO Radius in meters", 1660, t.Float, "The radius of the SSAO effect in the foreground"),
            ("AO Distance Strength", 1664, t.Float, "The strength of the SSAO effect in the distance"),
            ("AO Distance in Meters", 1668, t.Float, "The distance at which DistanceStrength takes full effect (0 = no distance-based modification)"),
            ("AO Sunlight Factor", 1672, t.Float, "The fraction of SSAO that's applied to direct sunlight"),
            ("AO Local Light Factor", 1676, t.Float, "The fraction of SSAO that's applied to direct local light"),
            ("AO Skin Unshadowed Factor", 1680, t.Float, "The fraction of SSAO that's applied to non-shadowed lights on skin materials"),
            ("AO Skin Shadowed Factor", 1684, t.Float, "The fraction of SSAO that's applied to shadowed lights on skin materials"),
            ("AO Ambient Shadow Draw Dist", 1688, t.Float, "The distance at which ambient shadows fade out"),
            ("AO Ambient Shadow Intensity", 1692, t.Float, "The strength of the ambient shadow effect"),
            //--------------------------------------------------------------------------------------

            //--------------------------------------------------------------------------------------
            ("AA Temporal Blend Strength", 1696, t.Float, ""),
            ("AA Temporal Sharpen Strength", 1700, t.Float, ""),
            ("SSR Strength", 1704, t.Float, ""),
            ("SSR RT Distance Scale", 1708, t.Float, "Reducing this value also reduces the number of RT models processed and improves CPU performance."),
            //--------------------------------------------------------------------------------------

            //--------------------------------------------------------------------------------------
            ("Weather Constant", 52, t.Float, "Sets the global material constant: WeatherConstant"),
            ("FX Splash Scale", 352, t.Float, ""),
            ("FX Splash Range", 356, t.Float, ""),
            ("FX Splash Rate", 360, t.Float, ""),
            ("Wetness", 368, t.Float, ""),
            ("Character Wetness Adjustment", 372, t.Float, ""),
            //--------------------------------------------------------------------------------------

            //--------------------------------------------------------------------------------------
            ("Particle color Red", 1160, t.Float, ""),
            ("Particle color Green", 1164, t.Float, ""),
            ("Particle color Blue", 1168, t.Float, ""),
            ("Particle alpha", 1172, t.Float, ""),
            ("Near Fade Distance", 1176, t.Float, "Particles fade away when they are closer to the camera than this distance."),
            ("Max Draw Distance", 1180, t.Float, "Particles fade away when they are further away from the camera than this distance."),
            ("Wind Influence", 1188, t.Float, "Determines how strongly the particles are affected by the atmosphere's wind property."),
            ("Turbulence", 1184, t.Float, "Determines how strongly the particles are affected by turbulence as they fall."),
            ("Density", 1196, t.Float, "Determines how many particles there are per unit volume."),
            ("Speed", 1192, t.Float, "Determines how fast the particles fall (use a negative number for falling particles)."),
            ("Density audio modifier", 1200, t.Float, "Value entered here will be multiplied by the Density value and sent to the Rain_Density_RTPC used by audio"),
            ("Size", 1204, t.Float, "Determines the physical size of each particle."),
            ("Exposure Duration", 1208, t.Float, "The fraction of the frame step that the camera's shutter is open and the particle is blurring."),
            ("Motion Stretch max near", 1212, t.Float, "Limits how much a particle can be stretched by motion blur to no more than this multiple of its unstretched width."),
            ("Motion Stretch max far", 1216, t.Float, "Same as MotionStretchMax, but applied to distant particles at the outer range of their draw distance. In between particles use an interpolated value between MotionStretchMax and MotionStretchMaxFar."),
            ("Bloom influence", 1220, t.Float, "The amount of energy from the previous frame's bloom buffer that feeds into particle lighting"),
            ("Lens Rain Emit Rate", 1224, t.Float, "Number of drops to emit per second. This is scaled down by rain density. Zero is off."),
            ("Lens Rain Max Drops", 1228, t.Float, "Maximum number of drops on the screen."),
            ("Lens Rain Steam", 1232, t.Float, "The amount of white that is added to the surface to simulate steam."),
            ("Lens Rain Streaks", 1236, t.Float, "A scale factor for the time before streaks start and the wait time for them to repeat."),
            ("Glint Randomness", 1240, t.Float, "Controls the degree of random directional spreading for the glinting effect."),
            ("Glint Frequency", 1244, t.Float, "Controls the frequency of the glinting effect."),
            ("Phase Scattering 0", 1248, t.Float, "Controls how directional the subsurface scattering is. 0 - light scatters uniformly in all directions, 1 = light scatters towards the viewer."),
            ("Phase Scattering 1", 1252, t.Float, "Controls how directional the subsurface scattering is. 0 - light scatters uniformly in all directions, 1 = light scatters towards the viewer."),
            ("Bokeh Scale", 1256, t.Float, "Scales the size of the weather particles based on Depth of Field to simulate Bokeh."),
            ("Bokeh Attenuation", 1260, t.Float, "Fades out the alpha of the weather particles based on Depth of Field."),

            //--------------------------------------------------------------------------------------
            ("Wind Intensity", 1264, t.Float, ""),
            ("Wind Azimuth", 1268, t.Float, ""),
            ("Gusts Min Intensity", 1272, t.Float, "Wind gust intensity in meter per second"),
            ("Gusts Max Intensity", 1276, t.Float, ""),
            ("Gusts Min Interval", 1280, t.Float, "The gap in seconds between two consecutive gusts"),
            ("Gusts Max Interval", 1284, t.Float, ""),
            ("Gusts Min Duration", 1288, t.Float, "The duration of each wind gust in seconds"),
            ("Gusts Max Duration", 1292, t.Float, ""),
            ("Vector field simulation max", 1296, t.Float, "The maximum distance that the wind simulation vector field will extend out to over the XZ plane."),
            ("Height Range Min", 1300, t.Float, "The min height for the wind simulation vector field."),
            ("Height Range Max", 1304, t.Float, "The max height for the wind simulation vector field."),
            ("Layers", 1308, t.Float, ""),
            //--------------------------------------------------------------------------------------

            //--------------------------------------------------------------------------------------
            ("Edge Displacement", 2704, t.Float, ""),
            ("Smooth slope threshold", 2708, t.Float, ""),
            ("Flow Slope Threshold", 2712, t.Float, ""),
            ("Flow Mask Duration", 2716, t.Float, ""),
            ("Wind Influence", 2720, t.Float, ""),
            ("Fade Out Time", 2724, t.Float, ""),
            ("Ocean Color Red", 632, t.Float, ""),
            ("Ocean Color Green", 636, t.Float, ""),
            ("Ocean Color Blue", 640, t.Float, ""),
            ("Wave amplitude", 512, t.Float, ""),
            ("Chop Scale", 516, t.Float, ""),
            ("Wind Speed", 536, t.Float, ""),
            ("Time Scale", 540, t.Float, ""),
            ("Darkening", 544, t.Float, ""),
            ("Depth", 548, t.Float, ""),
            ("Depth Bias", 552, t.Float, ""),
            ("Physical Color Blend", 480, t.Float, ""),
            ("Smooth Water Gloss", 492, t.Float, ""),
            ("Rough Water Gloss", 496, t.Float, ""),
            ("Biomass", 504, t.Float, ""),
            ("Absorption Depth", 508, t.Float, ""),
            ("Wind Independence", 644, t.Float, ""),
            ("SSR Perturb", 688, t.Float, ""),
            ("SSR Perturb Z", 560, t.Float, ""),
            ("Wave Elongate", 660, t.Float, ""),
            ("Reflection Level", 500, t.Float, ""),
            ("Water Sheeting Disable", 484, t.Float, ""),
            ("Water Displacement Disable", 488, t.Float, ""),

            //--------------------------------------------------------------------------------------
            ("Volumetric Fog Scattering Color Red", 1784, t.Float, "Controls light energy scattered through the fog. This can be used to tint or reduce the total light energy contribution from the fog."),
            ("Volumetric Fog Scattering Color Green", 1788, t.Float, ""),
            ("Volumetric Fog Scattering Color Blue", 1792, t.Float, ""),
            ("Volumetric Fog Density", 1796, t.Float, "0 = No volumetric fog, 1 = Thick volumetric fog that completely blocks the background"),
            ("Volumetric Fog Bottom Height", 1800, t.Float, ""),
            ("Volu  metric Fog Top Height", 1804, t.Float, ""),
            ("Near Distance", 1808, t.Float, "Distance near the camera with no volumetric fog"),
            ("Far Distance", 1812, t.Float, "Replace height fog with volumetric fog up to this distance"),
            ("Direct Light Scale", 1816, t.Float, "Contribution of direct light (sun/moon) to volumetric fog"),
            ("Lights Scale", 1820, t.Float, "Contribution of dynamic lights to volumetric fog"),
            ("GI Scale", 1824, t.Float, "Contribution of light grids to volumetric fog"),
            ("Noise Vertical Speed", 1828, t.Float, "How fast noise moves along the vertical axis"),
            ("Noise Wind Speed", 1832, t.Float, "How fast noise moves along the direction of the wind"),
            ("Noise", 1836, t.Float, "Injects Perlin noise to break up the intensity of the fog. The higher the value, the more the noise subtracts from the fog"),
            ("Noise Ratio", 1884, t.Float, "Blending ratio between high and low frequency perlin noise."),
            ("Use Chromatic Phase", 1852, t.Int, ""),
            ("Scattering Phase", 1856, t.Float, ""),
            ("Chromatic Phase RGB Red", 1860, t.Float, ""),
            ("Chromatic Phase RGB Green", 1864, t.Float, ""),
            ("Chromatic Phase RGB Blue", 1868, t.Float, ""),
            ("Slice distribution", 1872, t.Float, "Controls the volumetric depth slice distribution. values closer to 0 increase the quality near the view in exchange for lower quality at a distance. Increasing the value will improve quality at a distance in exchange for lower quality near the viewer."),
            ("Depth Occlusion", 1876, t.Float, "Controls depth occlusion scaling. 0 - no depth occlusion, 1 - fully enabled. This can increase the sampling quality of the volumetric fog using the depth buffer to clamp the max volumetric depth but may lead to some disocclusion artifacts around large near vs. far edges in the scene."),
            ("Absorption Color RGB Red", 1840, t.Float, ""),
            ("Absorption Color RGB Green", 1844, t.Float, ""),
            ("Absorption Color RGB Blue", 1848, t.Float, ""),
            //--------------------------------------------------------------------------------------

            ("Enable temporal upsampling", 1880, t.Int, ""),

            //--------------------------------------------------------------------------------------
            ("Ocean SSS Color Red", 584, t.Float, ""),
            ("Ocean SSS Color Green", 588, t.Float, ""),
            ("Ocean SSS Color Blue", 592, t.Float, ""),
            ("Ocean SSS Body Intensity", 580, t.Float, ""),
            ("Ocean SSS Wave Intensity", 596, t.Float, ""),
            ("Ocean SSS Ambient Intensity", 600, t.Float, ""),
            //--------------------------------------------------------------------------------------
        };

        public static List<(string Name, int Address, string Description)> Hashes = new() {
            ("Sky Box Image", 56, ""),
            ("Key Light Material", 168, ""),
            ("Dirtness Texture", 1384, ""),
            ("LUT Path (Deprecated)", 1592, ""),
            ("Color Map Texture", 1904, ""),
            ("Alpha Map", 1928, ""),
            ("Noise Texture", 1992, ""),
            ("Splashing Texture", 280, ""),
            ("Porosity Texture", 304, ""),
            ("Streak Texture", 328, ""),
            ("Particles Material", 1136, ""),
        };
    }
}
