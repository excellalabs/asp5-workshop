/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp'),
    xunit = require('gulp-xunit-runner'),
    jshint = require('gulp-jshint'),
    uglify = require('gulp-uglify'),
    del = require('del');

var paths = {
    bower: "./bower_components/",
    destination: "./wwwroot/scripts/"
};

gulp.task('default', function () {
    gulp.start(/*'unit-test',*/ 'jshint');
});

gulp.task('deploy', function () {
    gulp.start('jshint', 'clean', 'compress');
});

gulp.task('jshint', function () {
    gulp.src('./wwwroot/scripts/*.js')
      .pipe(jshint())
      .pipe(jshint.reporter('default'));
});

gulp.task('compress', function () {
    return gulp.src('./scripts/*.js')
      .pipe(uglify())
      .pipe(gulp.dest('./wwwroot/scripts/'));
});

gulp.task('clean', function (cb) {
    del('./wwwroot/scripts/', cb);
});

gulp.task('watch', function () {
    //on javascript change run jshint
    gulp.watch(['**/*.js']).on('change', ['jshint']);
});

gulp.task('unit-test', function () {
    return gulp.src(['**/*Tests.dll'], { read: false })
      .pipe(xunit({
          executable: 'D:/xunit-build-1705/xunit.console.exe',
      }));
});

