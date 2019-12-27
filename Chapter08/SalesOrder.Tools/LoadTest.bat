PUSHD ..\SalesOrder.Generate\bin\Debug\netcoreapp3.0\
for /l %%x in (1, 1, 10) do start SalesOrder.Generate.exe 10
POPD
