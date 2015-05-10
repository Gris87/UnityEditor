// This file generated from xml files in "Assets/Resources/res/values".
using System.Collections.Generic;



namespace UnityTranslation
{
    /// <summary>
    /// Container for all tokens specified in xml files in "Assets/Resources/res/values".
    /// </summary>
    public static class R
    {
        /// <summary>
        /// Enumeration of all string tags in "Assets/Resources/res/values/strings.xml"
        /// </summary>
        public enum strings
        {
            /// <summary>
            /// Total amount of strings.
            /// </summary>
            Count // Should be last
        }

        /// <summary>
        /// Enumeration of all string-array tags in "Assets/Resources/res/values/strings.xml"
        /// </summary>
        public enum array
        {
            /// <summary>
            /// Total amount of string-arrays.
            /// </summary>
            Count // Should be last
        }

        /// <summary>
        /// Enumeration of all plurals tags in "Assets/Resources/res/values/strings.xml"
        /// </summary>
        public enum plurals
        {
            /// <summary>
            /// Total amount of plurals.
            /// </summary>
            Count // Should be last
        }

        /// <summary>
        /// Container for dynamically loadable tokens specified in non strings.xml files.
        /// </summary>
        public static class sections
        {
            /// <summary>
            /// Section ID. This enumeration contains list of dynamically loadable sections.
            /// </summary>
            public enum SectionID
            {
                /// <summary>
                /// Section ID for "menu_items.xml" file.
                /// </summary>
                MenuItems
                ,
                /// <summary>
                /// Total amount of sections.
                /// </summary>
                Count // Should be last
            }

            /// <summary>
            /// Names of xml files for each section.
            /// </summary>
            public static readonly string[] xmlFiles = new string[]
            {
                  "menu_items.xml" // MenuItems
            };

            /// <summary>
            /// Container for all tokens specified in "Assets/Resources/res/values/menu_items.xml" file.
            /// </summary>
            public static class MenuItems
            {
                /// <summary>
                /// Enumeration of all string tags in "Assets/Resources/res/values/menu_items.xml"
                /// </summary>
                public enum strings
                {
                    /// <summary>
                    /// <para>Menu item : File</para>
                    /// <para>Value:</para>
                    ///   <para>File</para>
                    /// </summary>
                    file
                    ,
                    /// <summary>
                    /// <para>Menu item : File -&gt; New Scene</para>
                    /// <para>Value:</para>
                    ///   <para>New Scene</para>
                    /// </summary>
                    file__new_scene
                    ,
                    /// <summary>
                    /// <para>Menu item : File -&gt; Open Scene</para>
                    /// <para>Value:</para>
                    ///   <para>Open Scene</para>
                    /// </summary>
                    file__open_scene
                    ,
                    /// <summary>
                    /// <para>Menu item : File -&gt; Save Scene</para>
                    /// <para>Value:</para>
                    ///   <para>Save Scene</para>
                    /// </summary>
                    file__save_scene
                    ,
                    /// <summary>
                    /// <para>Menu item : File -&gt; Save Scene as...</para>
                    /// <para>Value:</para>
                    ///   <para>Save Scene as...</para>
                    /// </summary>
                    file__save_scene_as
                    ,
                    /// <summary>
                    /// <para>Menu item : File -&gt; New Project...</para>
                    /// <para>Value:</para>
                    ///   <para>New Project...</para>
                    /// </summary>
                    file__new_project
                    ,
                    /// <summary>
                    /// <para>Menu item : File -&gt; Open Project...</para>
                    /// <para>Value:</para>
                    ///   <para>Open Project...</para>
                    /// </summary>
                    file__open_project
                    ,
                    /// <summary>
                    /// <para>Menu item : File -&gt; Save Project</para>
                    /// <para>Value:</para>
                    ///   <para>Save Project</para>
                    /// </summary>
                    file__save_project
                    ,
                    /// <summary>
                    /// <para>Menu item : File -&gt; Build Settings...</para>
                    /// <para>Value:</para>
                    ///   <para>Build Settings...</para>
                    /// </summary>
                    file__build_settings
                    ,
                    /// <summary>
                    /// <para>Menu item : File -&gt; Build &amp; Run</para>
                    /// <para>Value:</para>
                    ///   <para>Build &amp; Run</para>
                    /// </summary>
                    file__build_and_run
                    ,
                    /// <summary>
                    /// <para>Menu item : File -&gt; Build in Cloud...</para>
                    /// <para>Value:</para>
                    ///   <para>Build in Cloud...</para>
                    /// </summary>
                    file__build_in_cloud
                    ,
                    /// <summary>
                    /// <para>Menu item : File -&gt; Exit</para>
                    /// <para>Value:</para>
                    ///   <para>Exit</para>
                    /// </summary>
                    file__exit
                    ,
                    /// <summary>
                    /// <para>Menu item : Edit</para>
                    /// <para>Value:</para>
                    ///   <para>Edit</para>
                    /// </summary>
                    edit
                    ,
                    /// <summary>
                    /// Total amount of strings.
                    /// </summary>
                    Count // Should be last
                }

                /// <summary>
                /// Enumeration of all string-array tags in "Assets/Resources/res/values/menu_items.xml"
                /// </summary>
                public enum array
                {
                    /// <summary>
                    /// Total amount of string-arrays.
                    /// </summary>
                    Count // Should be last
                }

                /// <summary>
                /// Enumeration of all plurals tags in "Assets/Resources/res/values/menu_items.xml"
                /// </summary>
                public enum plurals
                {
                    /// <summary>
                    /// Total amount of plurals.
                    /// </summary>
                    Count // Should be last
                }
            }
        }

        /// <summary>
        /// <para>Container for all token IDs in strings.xml (index 0) and in another sections</para>
        /// <para>Each element of tokenIds is an array with 3 elements inside:</para>
        /// <para>0: strings tokens</para>
        /// <para>1: array tokens</para>
        /// <para>2: plurals tokens</para>
        /// </summary>
        public static readonly Dictionary<string, int>[][] tokenIds = new Dictionary<string, int>[][]
        {
            new Dictionary<string, int>[] // Global
            {
                new Dictionary<string, int> // strings
                {
                }
                ,
                new Dictionary<string, int> // array
                {
                }
                ,
                new Dictionary<string, int> // plurals
                {
                }
            }
            ,
            new Dictionary<string, int>[] // MenuItems
            {
                new Dictionary<string, int> // strings
                {
                      { "file"                , (int)R.sections.MenuItems.strings.file }
                    , { "file__new_scene"     , (int)R.sections.MenuItems.strings.file__new_scene }
                    , { "file__open_scene"    , (int)R.sections.MenuItems.strings.file__open_scene }
                    , { "file__save_scene"    , (int)R.sections.MenuItems.strings.file__save_scene }
                    , { "file__save_scene_as" , (int)R.sections.MenuItems.strings.file__save_scene_as }
                    , { "file__new_project"   , (int)R.sections.MenuItems.strings.file__new_project }
                    , { "file__open_project"  , (int)R.sections.MenuItems.strings.file__open_project }
                    , { "file__save_project"  , (int)R.sections.MenuItems.strings.file__save_project }
                    , { "file__build_settings", (int)R.sections.MenuItems.strings.file__build_settings }
                    , { "file__build_and_run" , (int)R.sections.MenuItems.strings.file__build_and_run }
                    , { "file__build_in_cloud", (int)R.sections.MenuItems.strings.file__build_in_cloud }
                    , { "file__exit"          , (int)R.sections.MenuItems.strings.file__exit }
                    , { "edit"                , (int)R.sections.MenuItems.strings.edit }
                }
                ,
                new Dictionary<string, int> // array
                {
                }
                ,
                new Dictionary<string, int> // plurals
                {
                }
            }
        };
    }
}
