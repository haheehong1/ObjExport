using Grasshopper;
using Grasshopper.Kernel;
using Rhino.FileIO;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.IO;

namespace objexporttest
{
    public class objexporttestComponent : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public objexporttestComponent()
          : base("objExportTest", "objExportTest",
            "objExportTest",
            "SeEmo", "Subcategory")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBooleanParameter("Run", "Run", "Run", GH_ParamAccess.item);
            pManager.AddMeshParameter("SmoMesh", "M", "Seemo Meshes", GH_ParamAccess.list);
            pManager.AddTextParameter("Environment", "Env", "Environment Name", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {

            List<Mesh> meshes = new List<Mesh>();

            Boolean run = false;
            string envName = "default";

            if (!DA.GetData(0, ref run)) return;
            if (run == false) return;
            DA.GetDataList(1, meshes);
            if (!DA.GetData(2, ref envName)) return;


            //save rendering into bmp
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string dir = (path + @"\Seemo\");

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            string filename = dir + envName + ".obj";


            var fowo = new Rhino.FileIO.FileObjWriteOptions(new Rhino.FileIO.FileWriteOptions { SuppressAllInput = true })
            {
                ExportMaterialDefinitions = true,
                MapZtoY = true,
                MeshParameters = MeshingParameters.Default,
            };

            
            var result = Rhino.FileIO.FileObj.Write(filename, meshes.ToArray(), fowo);
        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// You can add image files to your project resources and access them like this:
        /// return Resources.IconForThisComponent;
        /// </summary>
        protected override System.Drawing.Bitmap Icon => null;

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid => new Guid("5187C517-6D02-4457-9191-3A4E607A3AF3");
    }
}