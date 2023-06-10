import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:my_money/providers/my_money_provider.dart';
import 'package:my_money/router/router.dart';
import 'package:provider/provider.dart';

void main() {
  runApp(
    // Provide the model to all widgets within the app. We're using
    // ChangeNotifierProvider because that's a simple way to rebuild
    // widgets when a model changes.
    ChangeNotifierProvider(
      // Initialize the model in the builder.
      create: (context) => MoneyProvider(),
      child: const MyApp(),
    ),
  );
}

// llamamos a nuestro router
final GoRouter _router = router();

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp.router(
      title: 'My Money App',
      theme: ThemeData(
        primarySwatch: Colors.green,
        useMaterial3: true,
      ),
      // configuramos nuestro router para la app
      routerConfig: _router,
    );
  }
}
