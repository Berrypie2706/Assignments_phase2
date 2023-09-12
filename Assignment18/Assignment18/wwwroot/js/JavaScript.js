
document.addEventListener("DOMContentLoaded", () => {
    const moviesList = document.getElementById("moviesList");
    const createMovie = document.getElementById("createMovie");
    const updateMovie = document.getElementById("updateMovie");
    const deleteMovie = document.getElementById("deleteMovie");

    function displayMovie() {
        fetch("https://localhost:7243/api/movies")
            .then(response => {
                if (!response.ok) {
                    throw new Error(`HTTP error! Status :${response.status}`);
                }
                return response.json();
            })
            .then(movies => {
                moviesList.innerHTML = "";
                movies.forEach(movie => {
                    const listitem = document.createElement("li");
                    listitem.textContent = `ID:${movie.id},Name:${movie.movieName},Genre :${movie.genre},Release Date :${movie.releaseDate}`;
                    moviesList.appendChild(listitem);
                });
            })
            .catch(error => {
                console.error("Fetch Error :", error);
                moviesList.innerHTML = "Error Fetching tasks."
            });
    }

    createMovie.addEventListener("submit", (e) => {
        e.preventDefault();
        const movieName = document.getElementById("movieName").value;
        const genre = document.getElementById("genre").value;
        const releaseDate = document.getElementById("releaseDate").value;

        fetch(`https://localhost:7243//api/movies`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ movieName, genre, releaseDate })
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error(`HTTP error! Status :${response.status}`);
                }
                return response.json();
            })
            .then(() => {
                //clear fields after successfull creation
                document.getElementById("movieName").value = "";
                document.getElementById("genre").value = "";
                document.getElementById("releaseDate").value = "";
                //refresh the tasklist
                displayMovie();
            })
            .catch(error => {
                console.error("Fetch Error :", error);
            });
    });
    updateMovie.addEventListener("submit", (e) => {
        e.preventDefault();
        const movieId = document.getElementById("movieId").value;
        const newTitle = document.getElementById("newMovieName").value;
        const newGenre = document.getElementById("newGenre").value;
        const newReleaseDate = document.getElementById("newReleaseDate").value;

        fetch(`https://localhost:7243/api/movies/${movieId}`, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ id: movieId, movieName: newMovieName, genre: newGenre, releaseDate: newReleaseDate })
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error(`HTTP error! Status :${response.status}`);
                }
                return response.json();
            })
            .then(() => {
                document.getElementById("movieId").value = "";
                document.getElementById("newMovieName").value = "";
                document.getElementById("newGenre").value = "";
                document.getElementById("newReleaseDate").value = "";
                displayMovie();
            })
            .catch(error => {
                console.error("Fetch Error :", error);
            });
    });
    //Event Listener for Delete Task Form Submission
    deleteMovie.addEventListener("submit", (e) => {
        e.preventDefault();
        const deletemovieId = document.getElementById("deletemovieId").value;

        fetch(`https://localhost:7243/api/movies/${deletemovieId}`, {
            method: "DELETE"
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error(`HTTP error! Status :${response.status}`);
                }
                return response.json();
            })
            .then(() => {
                document.getElementById("deletemovieId").value = "";
                displayMovie();
            })
            .catch(error => {
                console.error("Fetch Error :", error);
            });
    });

    displayMovie();

});