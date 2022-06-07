using Grasshopper;
using Grasshopper.Kernel;
using System;
using System.Drawing;

namespace objexporttest
{
    public class objexporttestInfo : GH_AssemblyInfo
    {
        public override string Name => "objexporttest";

        //Return a 24x24 pixel bitmap to represent this GHA library.
        public override Bitmap Icon => null;

        //Return a short string describing the purpose of this GHA library.
        public override string Description => "";

        public override Guid Id => new Guid("2DF43B9B-96D5-4D92-ADD2-D9B0927B94BA");

        //Return a string identifying you or your company.
        public override string AuthorName => "";

        //Return a string representing your preferred contact details.
        public override string AuthorContact => "";
    }
}