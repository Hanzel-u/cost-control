import 'package:go_router/go_router.dart';
import 'package:my_money/controllers/prefs_controller.dart';

resetData(context) {
  cleanValues();
  GoRouter.of(context).pushReplacement('/budget');
}
