# (C#) CommonValidator
Construct entity validation rules using anonymous functions in a builder pattern oriented style.


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

Database rules are not really working yet:
```C#
.AddDatabaseRule((q, s) => !q.Contains(s))
```
