SRC = ProjectRSA
TARGET = Program

default: build run clean

build:
	dotnet build;

run:
	cd $(SRC); \
	dotnet run;