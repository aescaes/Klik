﻿$(document).ready(function () {
    $("#game-log").DataTable({
        searching: false,
        pageLength: 5,
        bLengthChange: false,
        lengthMenu: [[5, 10, -1], [5, 10, "All"]]
    });

    var gameScore;
    var gameDifficulty;

    /*
     * fills page's remaining vertical space for game section
     */
    function gameSectionFillSpace() {
        var remainingSpace = $(window).height() - $("#header").height();
        $("#game-section").height(remainingSpace - 120);
    }

    /*
     * returns random number with min and max
     */
    function randomNum(min, max) {
        return Math.floor(Math.random() * max) + min;
    }

    /*
     * returns random shape
     */
    function getShape() {
        var shape = randomNum(1, 2);

        switch (shape) {
        case 1:
            shape = "circle";
            break;
        case 2:
            shape = "square";
            break;
        }

        return shape;
    }
    /*
     * new game
     */
    function newGame() {
        $("#game-result").fadeOut("slow", function () {
            $("#difficulty-menu").fadeIn("slow");
        });
    }
    /*
     * show result
     */
    function showResult(score, difficulty) {
        $("#game-status, #game-section").fadeOut("slow",
            function () {
                $("#result").html(score);
                $("#game-result").fadeIn("slow");

                $("#Score").val(score);

                switch (difficulty) {
                case "easy":
                    difficulty = 1;
                    break;
                case "medium":
                    difficulty = 2;
                    break;
                case "hard":
                    difficulty = 3;
                    break;
                }

                $("#DifficultyId").val(difficulty);
            }
        );

        $("#btn-play").click(function () {
            newGame();
        });
    }

    /*
     * creates new element
     */
    function newElement(shape, size) {
        var element = ".element-" + shape;

        //removes current element first before creating new one
        $(".element").remove();

        $("#game-section").append("<button class='element-" + shape + " element'></button>");

        //element size
        $(element).width(size);
        $(element).height(size);

        //element random position
        $(element).css("top", randomNum(0, $("#game-section").height() - size));
        $(element).css("left", randomNum(0, $("#game-section").width() - size));

        // updates score
        $(".element").click(
            // increments score by 1
            function () {
                gameScore++;
                $("#game-score").html(gameScore);
            }
        );
    }

    /*
     * starts game
     */
    function startGame(size, interval) {
        var time = 60; //game time in second
        // start time
        var gameTime = setInterval(function () {
                time--;
                $("#game-time").html(time + "s");

                if (time === 0) {
                    clearInterval(gameTime);
                    $(".element").remove();
                }
            },
            1000);

        // create new element on initialization
        newElement(getShape(), size);

        var elementInterval = setInterval(
            /*
             * removes current element after the set interval
             * in second then immediately creates new element
             */
            function () {
                if (time > 0) {
                    newElement(getShape(), size);
                }

                if (time === 0) {
                    clearInterval(elementInterval);
                    showResult(gameScore, gameDifficulty);
                }
            },
            interval * 1000
        );
    }

    /*
     * transition to game section after choosing difficulty
     */
    function enterGame(size, interval) {
        gameScore = 0; // reset score
        $("#game-score").html(gameScore);
        $("#game-time").html("60s");
        $("#countdown").show().html("The game will start in 3");

        $("#difficulty-menu").fadeOut("slow",
            function () {
                $("#game-section, #game-status").fadeIn("slow",
                    /*
                     * countdown
                     */
                    function () {
                        var countdownTime = 3; //countdown time in second
                        // countdown before game start
                        var countdown = setInterval(function () {
                                countdownTime--;
                                $("#countdown").html("The game will start in " + countdownTime);

                                if (countdownTime === 0) {
                                    clearInterval(countdown);
                                    $("#countdown").hide();

                                    // game start
                                    startGame(size, interval);
                                }
                            },
                            1000);
                    }
                );
            });
    }

    // fill space for game section
    gameSectionFillSpace();

    // fill space for game section in resize
    $(window).resize(function () {
        gameSectionFillSpace();
    });

    // set difficulty
    $(".btn-difficulty").click(function () {
        //difficulty properties
        gameDifficulty = $(this).attr("id");
        var interval = 0;
        var size = 0;

        //setting difficulty properties
        switch (gameDifficulty) {
        case "easy":
            interval = 3;
            size = 100;
            break;
        case "medium":
            interval = 2;
            size = 50;
            break;
        case "hard":
            interval = 1;
            size = 30;
            break;
        }

        enterGame(size, interval);
    });
});