dist-clean:
	rm -r dist
	mkdir -p dist/plugin

dll: 
	dotnet clean
	dotnet build

dist: dist-clean dll
	cp bin/Release/**/*.dll dist/plugin/
	
build: dist
	tcli build
