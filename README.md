# (C#) CommonValidator
Tool for constructing entity validation rules using predicates in a builder pattern oriented style.


## Example:
```C#
   string majesticTestingString = "Hello";

            
            CommonValidator<string> v = new CommonValidatorBuilder<string>()
                                    .AddSimpleRule(s => s.Length < 10)
                                    .AddSimpleRule(s => s.Length > 0)
                                    .AddDatabaseRule((q, s) => !q.Contains(s))
                                    .Build();

            v.Validate(majesticTestingString);  // => TRUE
```
