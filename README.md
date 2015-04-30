# Test applications for embedded frameworks in Xamarin.iOS

## embedded-framework (MyFramework.framework)

This is a sample Objective-C framework (MyFramework.framework), used by other
projects. This can be rebuilt by simply executing `make`, although the binary
is also checked in for easy consumption.

## simpleapp

This is a single app with one extension, to demonstrate how Mono.framework is
embedded inside the app bundle and used by both the extension and the main
app.

## simpleapp-with-framework

This is the same app as 'simpleapp' from above, with a binding project that
binds the MyFramework.framework, which is used in both the extension and the
main app.

## simpleapp-with-nativereferences

This is the same app as 'simpleapp' from above, now including
MyFramework.framework using the Native Reference support in the project files
(in both the extension and the container app).

## hugeapp

This is an app with all possible extensions. This can be used to see how much
space is saved when Xamarin.iOS embeds the Mono runtime as a framework once,
instead of linking it statically into every binary.

