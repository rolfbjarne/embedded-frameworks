
MyFramework.framework/MyFramework: MyFramework.device MyFramework.simulator
	lipo -create MyFramework.device MyFramework.simulator -output $@

CODE=code.c objc.m 

MyFramework.device: $(CODE) Makefile
	xcrun --sdk iphoneos        clang -dynamiclib $(CODE) -arch armv7 -arch armv7s -arch arm64 -o$@ -framework Foundation -fapplication-extension
	install_name_tool -id @rpath/MyFramework.framework/MyFramework $@

MyFramework.simulator: $(CODE) Makefile
	xcrun --sdk iphonesimulator clang -dynamiclib $(CODE) -arch i386 -arch x86_64              -o$@ -framework Foundation -fapplication-extension -mios-simulator-version-min=8.0
	install_name_tool -id @rpath/MyFramework.framework/MyFramework $@


