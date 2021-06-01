
$properties_string = @"
Calories

Fat
MonounsaturatedFat
PolyunsaturatedFat
Omega-3
Omega-6
SaturatedFat
TransFat
Cholesterol

Sodium

Carbohydrates
Fiber
SolubleFiber
InsolubleFiber
Starch
Sugars
AddedSugars

Protein

VitaminD
Calcium
Iron
Potassium
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
[ValidateNever]
public override decimal $property
{
    get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.$property);
    set { }
}
"@

''

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
