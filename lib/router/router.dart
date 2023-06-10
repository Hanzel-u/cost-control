/// Archivo que controla las rutas de la aplicación

import 'package:go_router/go_router.dart';
import 'package:my_money/screens/budget.dart';
import 'package:my_money/screens/expense.dart';
import 'package:my_money/screens/home.dart';

GoRouter router() {
  return GoRouter(
    initialLocation: "/budget",
    routes: [
      GoRoute(
        path: '/budget',
        builder: (context, state) => const Budget(),
      ),
      GoRoute(
        path: '/home',
        builder: (context, state) => const Home(),
      ),
      GoRoute(path: '/expense', builder: (context, state) => const Expense()),
    ],
  );
}
