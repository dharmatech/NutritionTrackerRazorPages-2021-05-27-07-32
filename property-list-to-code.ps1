
$properties_string = @"
Calories

Fat
MonounsaturatedFat
PolyunsaturatedFat
Omega3
Omega6
SaturatedFat
TransFat
Cholesterol

Carbohydrates
Fiber
SolubleFiber
InsolubleFiber
Starch
Sugars
AddedSugars

Protein

VitaminB1
VitaminB2
VitaminB3
VitaminB5
VitaminB6
VitaminB12

Folate

VitaminA
VitaminC
VitaminD
VitaminE
VitaminK


Calcium
Copper
Iron
Magnesium
Manganese
Phosphorus
Potassium
Selenium
Sodium
Zinc
"@

$properties = $properties_string.Split([Environment]::NewLine, [System.StringSplitOptions]::RemoveEmptyEntries)

# ----------------------------------------------------------------------
'// Food.cs'

foreach ($property in $properties)
{

@"
public abstract decimal {0,-18} {{ get; set; }}
"@ -f $property

}

''
# ----------------------------------------------------------------------
'// SimpleFood.cs'

foreach ($property in $properties)
{

@"
public override decimal {0,-18} {{ get; set; }}
"@ -f $property

}

''
# ----------------------------------------------------------------------
'// ComplexFood.cs'

foreach ($property in $properties)
{

@"
[ValidateNever] public override decimal {0,-18} {{ get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.{0}); set {{ }} }}
"@ -f $property

}
# ----------------------------------------------------------------------
'// ComplexFoodComponent.cs'

foreach ($property in $properties)
{

@"
[ValidateNever] public decimal {0,-18} => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.{0};
"@ -f $property

}

''
# ----------------------------------------------------------------------
'// FoodRecord.cs'

foreach ($property in $properties)
{

@"
[ValidateNever] public decimal {0,-18} => Amount / Food.ServingSize * Food.{0};
"@ -f $property

}

''
# ----------------------------------------------------------------------
'// Pages\FoodRecords\IndexGrouped.cshtml'

foreach ($property in $properties)
{

@"
<th>@Html.DisplayNameFor(model => model.FoodRecord[0].{0})</th>
"@ -f $property

}

''

foreach ($property in $properties)
{

@"
<td>@Utils.Misc.RoundData(item.{0})</td>
"@ -f $property

}

''

foreach ($property in $properties)
{

@"
<td>@Utils.Misc.RoundData(group_time.Sum(healthRecord => healthRecord.{0}))</td>
"@ -f $property

}

''

foreach ($property in $properties)
{

@"
<td>@Utils.Misc.RoundData(group_date.Sum(healthRecord => healthRecord.{0}))</td>
"@ -f $property

}

''
# ----------------------------------------------------------------------

'IndexTabulator.cshtml'

foreach ($property in $properties)
{

@"
{0,-18}: "@(Utils.Misc.RoundData(elt.{0}))",
"@ -f $property

}

''

foreach ($property in $properties)
{

@"
{{ title: {0,-21} field: "{1}" }},
"@ -f "`"$property`",", $property

}

# ----------------------------------------------------------------------

'IndexDevExtreme.cshtml'

foreach ($property in $properties)
{

@"
{0,-18}: "@(Utils.Misc.RoundData(elt.{0}))",
"@ -f $property

}

''

foreach ($property in $properties)
{

@"
{{ dataField: {0,-21} caption: {0,-21} }},
"@ -f "`"$property`",", $property

}

''

foreach ($property in $properties)
{

@"
{{ column: {0,-21} summaryType: "sum", alignByColumn: true, displayFormat: "{{0}}", valueFormat: "fixedPoint" }},
"@ -f "`"$property`","

}

''

foreach ($property in $properties)
{
@"
`$("#dataGrid").dxDataGrid("columnOption", {0,-21} "visible", true)
"@ -f "`"$property`","
}

''




