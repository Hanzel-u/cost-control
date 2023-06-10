import 'package:flutter/material.dart';

class MyPieChart extends StatelessWidget {
  final int budget;
  final int expenses;

  MyPieChart({required this.budget, required this.expenses});

  @override
  Widget build(BuildContext context) {
    double percentage = (expenses / budget) * 100;

    return Center(
      child: Stack(
        children: [
          Container(
            width: double.infinity,
            height: double.infinity,
            child: CircularProgressIndicator(
              value: percentage / 100,
              strokeWidth: 10,
            ),
          ),
          Expanded(
            child: Center(
              child: Text(
                '${percentage.toStringAsFixed(2)}% Gastado',
                style: TextStyle(fontSize: 16),
              ),
            ),
          ),
        ],
      ),
    );
  }
}