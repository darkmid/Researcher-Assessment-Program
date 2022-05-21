﻿#pragma checksum "..\..\ResearcherListView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "982C72BB240B56BB9BCFCAC99F58E43234FF3FCBAD0B772485017482CCC11C42"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using RAP.Research;
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


namespace RAP {
    
    
    /// <summary>
    /// ResearcherListView
    /// </summary>
    public partial class ResearcherListView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\ResearcherListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ResearcherSearchBox;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\ResearcherListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ResearcherLevelBox;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\ResearcherListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ResearcherList;
        
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
            System.Uri resourceLocater = new System.Uri("/RAP;component/researcherlistview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ResearcherListView.xaml"
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
            this.ResearcherSearchBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 33 "..\..\ResearcherListView.xaml"
            this.ResearcherSearchBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.ResearcherSearchBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ResearcherLevelBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 36 "..\..\ResearcherListView.xaml"
            this.ResearcherLevelBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ResearcherLevelBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ResearcherList = ((System.Windows.Controls.ListBox)(target));
            
            #line 39 "..\..\ResearcherListView.xaml"
            this.ResearcherList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ResearcherList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 58 "..\..\ResearcherListView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ReportButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
