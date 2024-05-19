# Rollover Number

Small library providing a rollover number.

## Example

```cs
var num = new RolloverNumber<int>(1, 3); // 1
num++; // 2
num++; // 3
num++; // 1
num++; // 2
num++; // 3
num--; // 2
num--; // 1
num--; // 3
```