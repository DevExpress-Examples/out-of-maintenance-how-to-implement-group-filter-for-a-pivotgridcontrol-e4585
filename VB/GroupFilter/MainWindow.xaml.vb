Imports System.Windows
Imports GroupFilter.nwindDataSetTableAdapters
Imports DevExpress.Xpf.PivotGrid

Namespace GroupFilter
	Partial Public Class MainWindow
		Inherits Window

		Public Sub New()
			InitializeComponent()
			Dim salesPersonDataAdapter As New SalesPersonTableAdapter()

			' Binds the pivot grid to data.
			pivotGridControl1.DataSource = salesPersonDataAdapter.GetData()

			' Creates a group and adds two fields to it.
			Dim OrderDateGroup As PivotGridGroup = pivotGridControl1.Groups.Add(pivotGridControl1.Fields(2), pivotGridControl1.Fields(3))

			' Locks the PivotGroupFilterValues object by disabling visual updates.
			OrderDateGroup.FilterValues.BeginUpdate()

			' Sets a filter type. 
			' It specifies that the PivotGridControl should display only filter values.
			OrderDateGroup.FilterValues.FilterType = FieldFilterType.Included

			' Creates a filter value and adds it to the PivotGroupFilterValues.Values collection.
			OrderDateGroup.FilterValues.Values.Add(1994)

			' Creates a filter value and adds it to the PivotGroupFilterValues.Values collection.
			' Then creates a child value of the filter value and adds it to the parent value 
			' collection.
			OrderDateGroup.FilterValues.Values.Add(1995).ChildValues.Add(1)

			' Unlocks the PivotGroupFilterValues object.
			OrderDateGroup.FilterValues.EndUpdate()
		End Sub
	End Class
End Namespace
