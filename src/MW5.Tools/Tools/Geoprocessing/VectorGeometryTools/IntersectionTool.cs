﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntersectionTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   Defines the Intersection Tool.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using MW5.Api.Enums;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Tools.Model;

namespace MW5.Tools.Tools.Geoprocessing.VectorGeometryTools
{
    [GisTool(GroupKeys.VectorGeometryTools)]
    public class IntersectionTool : GisTool
    {
        [Input("First layer", 0)]
        public VectorLayerInfo InputLayer { get; set; }

        [Input("Second layer", 1)]
        public VectorLayerInfo InputLayer2 { get; set; }

        [Input("Save results as", 2)]
        [DefaultValue("intersection")]
        public OutputLayerInfo Output { get; set; }

        /// <summary>
        /// Gets description of the tool.
        /// </summary>
        public override string Description
        {
            get { return "Calculates intersection of 2 vector layers."; }
        }

        /// <summary>
        /// Gets name of the tool.
        /// </summary>
        public override string Name
        {
            get { return "Intersection"; }
        }

        /// <summary>
        /// Provide execution logic for the tool.
        /// </summary>
        public override bool Run(ITaskHandle task)
        {
            var fs = InputLayer.Datasource;
            var fs2 = InputLayer2.Datasource;

            var result = fs.Intersection(InputLayer.SelectedOnly, fs2, InputLayer2.SelectedOnly, GeometryType.None);

            Output.Result = result;

            return result != null;
        }

        /// <summary>
        /// Handles the result.
        /// </summary>
        public override bool AfterRun()
        {
            if (Output.Result != null)
            {
                SaveOutput(Output.Result, Output);
                return true;
            }

            return false;
        }
    }
}