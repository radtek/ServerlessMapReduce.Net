rm -f ~/FileObjectStore/ingested/*
rm -f ~/FileObjectStore/mapped/*
rm -f ~/FileObjectStore/reduced/*
rm -Rf ~/FileObjectStore/workerRecord/*
rm -f ~/FileObjectStore/finalReduction/*
dotnet src/ServerlessMapReduceDotNet/bin/Debug/netcoreapp2.0/ServerlessMapReduceDotNet.dll raw/MakeModel2016.csv raw/cars-registered-2016.csv
