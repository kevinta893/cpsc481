﻿#pragma checksum "..\..\..\..\Pages\RecipeCompleteSteps.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8D073871579FE53AE84881F98B4B8129"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace HCI_Cooking.Pages {
    
    
    /// <summary>
    /// RecipeCompleteSteps
    /// </summary>
    public partial class RecipeCompleteSteps : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\Pages\RecipeCompleteSteps.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grdRCompSteps;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Pages\RecipeCompleteSteps.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRecipeCompBack;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Pages\RecipeCompleteSteps.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox rTxtBlkSteps;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Pages\RecipeCompleteSteps.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIndivToggleView;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HCI Cooking;component/pages/recipecompletesteps.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\RecipeCompleteSteps.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.grdRCompSteps = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.btnRecipeCompBack = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\..\Pages\RecipeCompleteSteps.xaml"
            this.btnRecipeCompBack.Click += new System.Windows.RoutedEventHandler(this.btnRecipeCompBack_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.rTxtBlkSteps = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 4:
            this.btnIndivToggleView = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\Pages\RecipeCompleteSteps.xaml"
            this.btnIndivToggleView.Click += new System.Windows.RoutedEventHandler(this.btnCompToogleView_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

